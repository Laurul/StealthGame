using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectShadow : MonoBehaviour
{
    public Light sun;

    private MeshRenderer mesh;
    private RaycastHit hit;
    private bool underSun = true;

    // Use this for initialization
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        underSun =true;
        Vector3 sunDir = sun.transform.forward;
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
                underSun =false;
            }

        }



        if (underSun)
        {
            mesh.material.color = Color.blue;
        }
        else
        {
            mesh.material.color = Color.green;
        }

     

    }

    public bool ReturnCover()
    {
        return underSun;
    }
}
