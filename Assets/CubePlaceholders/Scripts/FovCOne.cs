using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FovCOne : MonoBehaviour
{
    // Start is called before the first frame update
    public float viewRadius;
    [Range(0,360)]
    public float viewAngle;
    public LayerMask targetMask;
    public LayerMask obstacleMask;
    public float meshResolution;

    public MeshFilter viewMeshFilter;
    Mesh viewMesh;

    public int edgeIterationCounter;

    public float edgeDistanceTreshhold;

    public List<Transform> targets = new List<Transform>();
    [SerializeField] DetectShadow playerInShadow;

    bool alert = false;
   EnemyAI enemy;
 
    float f=0;
    private void Start()
    {
        enemy = GetComponent<EnemyAI>();
        viewMesh = new Mesh();
        viewMesh.name = "View Mesh";

        viewMeshFilter.mesh = viewMesh;

        StartCoroutine("FindTargets", .5f);
    }
    IEnumerator FindTargets(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindTargetsInView();
        }
    }
    void FindTargetsInView()
    {
        targets.Clear();
        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);
        for(int i = 0; i < targetsInViewRadius.Length; i++)
        {
            Transform target = targetsInViewRadius[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;
            f = Vector3.Distance(transform.position, target.position);
            if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)
            {
                float distToTarget = Vector3.Distance(transform.position, target.position);
                if (!Physics.Raycast(transform.position, dirToTarget, distToTarget, obstacleMask))
                {
                    targets.Add(target);
                    //alert = true;
                    GameManager.Instance.alert = true;
                   
                   
                    //tell character to run to target location, shoot target, etc;
                }

            }
            else if (Vector3.Angle(transform.forward, dirToTarget) >= viewAngle / 2)
            {
                GameManager.Instance.alert = false;
            }
           
        }
        if (targetsInViewRadius.Length == 0)
        {
            GameManager.Instance.alert = false;

            // alert = false;
        }
    }


    private void Update()
    {
        //print(targets.Count);
        
        //if (alert)
        //{ 
        //    if (playerInShadow.ReturnCover())
        //    {
        //        enemy.GetComponentInChildren<FadeColor>().IncreaseOpacity(0.01f);
        //    }
        //    else
        //    {
        //        enemy.GetComponentInChildren<FadeColor>().IncreaseOpacity(0.004f);
        //    }
           
        //}
        
        //if(alert==false)
        //{
            
        //    enemy.GetComponentInChildren<FadeColor>().IncreaseFade(0.01f);
        //}


        //if (enemy.GetComponentInChildren<FadeColor>().GetAlphaValue() >= 1.0f)
        //    // enemy.FollowPlayer();
        //    enemy.changeTarget = true;
           

        //if (enemy.GetComponentInChildren<FadeColor>().GetAlphaValue() <= 0.0f)
        //{
        //    enemy.changeTarget = false;
        //    // new WaitForSeconds(0.2f);
        //    //enemy.StopFollowPlayer();
        //}
        ////if(targets.Count>0)
        ////foreach(Transform target in targets)
        ////{
        ////    print(target.gameObject.name);
        ////}
    }

    private void LateUpdate()
    {
        DrawFOV();
    }
    public Vector3 VectorFromAngle(float angle,bool globalAngle)
    {
        if (!globalAngle)
        {
            angle += transform.eulerAngles.y;
        }
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Sin(angleRad),0, Mathf.Cos(angleRad));
    }

    void DrawFOV()
    {
        int stepCount = Mathf.RoundToInt( viewAngle * meshResolution);
        float stepAngleSize = viewAngle / stepCount;

        List<Vector3> viewPoints = new List<Vector3>();
        ViewCastInfo oldViewCast = new ViewCastInfo();

        for(int i = 0; i <= stepCount; i++)
        {
            float angle = transform.eulerAngles.y-viewAngle/2+stepAngleSize*i;
            ViewCastInfo newViewCast = ViewCast(angle);


            if (i > 0)
            {
                bool edgeDistExceeded=Mathf.Abs(oldViewCast.dst-newViewCast.dst)>edgeDistanceTreshhold;
                if (oldViewCast.hit != newViewCast.hit||(oldViewCast.hit && newViewCast.hit&&edgeDistExceeded))
                {
                    EdgeInfo edge = FindEdge(oldViewCast, newViewCast);
                    if (edge.minPoint != Vector3.zero)
                    {
                        viewPoints.Add(edge.minPoint);
                    }
                    if (edge.maxPoint != Vector3.zero)
                    {
                        viewPoints.Add(edge.maxPoint);
                    }
                }
            }

            viewPoints.Add(newViewCast.point);
            oldViewCast = newViewCast;
        }

        int vertexCount = viewPoints.Count + 1;
        Vector3[] verts = new Vector3[vertexCount];
        int[] tris = new int[(vertexCount - 2) * 3];

        verts[0] = Vector3.zero;

        for(int j = 0; j < vertexCount - 1; j++)
        {
            if (j < vertexCount - 2)
            {
                verts[j + 1] =transform.InverseTransformPoint( viewPoints[j]);
                tris[j * 3] = 0;
                tris[(j * 3) + 1] = j + 1;
                tris[(j * 3) + 2] = j + 2;
            }
           
        }


        viewMesh.Clear();
        viewMesh.vertices = verts;
        viewMesh.triangles = tris;
        viewMesh.RecalculateNormals();
    }

    ViewCastInfo ViewCast(float globalAngle)
    {
        Vector3 dir = VectorFromAngle(globalAngle, true);
        RaycastHit hit;
        if(Physics.Raycast(transform.position,dir,out hit, viewRadius, obstacleMask))
        {
            return new ViewCastInfo(true, hit.point, hit.distance, globalAngle);
        }
        else
        {
            return new ViewCastInfo(false, transform.position+dir*viewRadius,viewRadius, globalAngle);
        }
    }

    public struct ViewCastInfo
    {
        public bool hit;
        public Vector3 point;
        public float dst;
        public float angle;

        public ViewCastInfo(bool _hit, Vector3 _point, float _dst, float _angle)
        {
            hit = _hit;
            point = _point;
            dst = _dst;
            angle = _angle;
        }
    }

    public struct EdgeInfo
    {
        public Vector3 minPoint;
        public Vector3 maxPoint;

        public EdgeInfo(Vector3 _minPoint,Vector3 _maxPoint)
        {
            minPoint = _minPoint;
            maxPoint = _maxPoint;
        }
    }

    EdgeInfo FindEdge(ViewCastInfo minViewCast,ViewCastInfo maxViewCast)
    {
        float minAngle = minViewCast.angle;
        float maxAngle = maxViewCast.angle;
        Vector3 minpoint = Vector3.zero;
        Vector3 maxpoint = Vector3.zero;

        for(int i = 0; i < edgeIterationCounter; i++)
        {
            float angle = (minAngle + maxAngle) / 2;
            ViewCastInfo newViewCast = ViewCast(angle);

            bool edgeDistExceeded = Mathf.Abs(minViewCast.dst - newViewCast.dst) > edgeDistanceTreshhold;


            if (newViewCast.hit == minViewCast.hit&&!edgeDistExceeded)
            {
                minAngle = angle;
                minpoint = newViewCast.point;
            }
            else
            {
                maxAngle = angle;
                maxpoint = newViewCast.point;
            }
        }

        return new EdgeInfo(minpoint, maxpoint);
    }
}
