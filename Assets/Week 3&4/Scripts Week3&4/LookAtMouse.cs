using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
   
    
   void Update()
    {
        Ray cam = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane ground = new Plane(Vector3.up, Vector3.zero);
        float length;

        if(ground.Raycast(cam, out length))
        {
            Vector3 point = cam.GetPoint(length);
           
            transform.LookAt(new Vector3(point.x,transform.position.y,point.z));
        }

      
    }

}
