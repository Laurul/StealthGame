using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVent : MonoBehaviour
{
    GameObject[] tiles;
   public  bool isVented = false;
    bool doOnce = false;
   [SerializeField] Material transparentMat;
    Color c;
    // Start is called before the first frame update
    void Start()
    {
        tiles = GameObject.FindGameObjectsWithTag("transparent");
        //tiles = transparentPath.GetComponentsInChildren<MeshRenderer>();
        c = transparentMat.color;
        c.a = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isVented)
        {
           foreach(GameObject tile in tiles)
            {

                var block = new MaterialPropertyBlock();

          
                block.SetColor("_BaseColor", Color.clear);

                tile.GetComponent<Renderer>().SetPropertyBlock(block);
            }
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
            foreach (GameObject tile in tiles)
            {

                var block = new MaterialPropertyBlock();


                block.SetColor("_BaseColor", transparentMat.color) ;

                tile.GetComponent<Renderer>().SetPropertyBlock(block);
            }

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
