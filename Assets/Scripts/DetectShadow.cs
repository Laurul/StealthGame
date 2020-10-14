using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectShadow : MonoBehaviour
{
    public Light lightSource;

    private MeshRenderer mesh;
    private RaycastHit hit;
    private bool hitsLight = true;

    // Use this for initialization
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        hitsLight =true;
        Vector3 sunDir = lightSource.transform.forward;
        sunDir.Normalize();
        sunDir *= 100;

        foreach (Transform child in transform)
        {

            if (!Physics.Raycast(child.position, -1f * sunDir, 30, LayerMask.GetMask("Obstacle")))
            {

                Debug.DrawLine(child.position, child.position - sunDir, Color.red);
               

            }
            else
            {
                Debug.DrawLine(child.position, child.position - sunDir, Color.green);
                hitsLight =false;
            }

        }



        if (hitsLight)
        {
            mesh.material.color = Color.white;
        }
        else
        {
            mesh.material.color = Color.cyan;
        }

     

    }

    public bool ReturnCover()
    {
        return hitsLight;
    }
}
