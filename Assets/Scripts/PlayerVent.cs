using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVent : MonoBehaviour
{
    //[SerializeField] GameObject transparentPath;
   // MeshRenderer[] tiles;
   public  bool isVented = false;
    bool doOnce = false;
   [SerializeField] Material transparentMat;
    Color c;
    // Start is called before the first frame update
    void Start()
    {
        //tiles = transparentPath.GetComponentsInChildren<MeshRenderer>();
        c = transparentMat.color;
        c.a = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isVented)
        {
            c.a = 0.2f;
            transparentMat.color = c;
            if (doOnce == true)
            {
                doOnce = false;
                this.transform.position = new Vector3(transform.position.x, transform.position.y - 2, transform.position.z);
            }
            
            //foreach(MeshRenderer t in tiles)
            //{
            //    t.enabled = false;
            //}
            
        }
        else
        {
            c.a = 1f;
            transparentMat.color = c;
            if (doOnce ==true)
            {
                doOnce = false;
                this.transform.position = new Vector3(transform.position.x, transform.position.y + 4, transform.position.z);
            }
            //foreach (MeshRenderer t in tiles)
            //{
            //    t.enabled = true;
            //}
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "vent")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                isVented = !isVented;
                doOnce = true;
            }
        }
    }

    public bool GetVentStatus()
    {
        return isVented;
    }
}
