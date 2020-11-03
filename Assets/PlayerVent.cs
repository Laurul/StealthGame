using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVent : MonoBehaviour
{
    [SerializeField] GameObject transparentPath;
    MeshRenderer[] tiles;
    bool isVented = false;
    bool doOnce = false;
    // Start is called before the first frame update
    void Start()
    {
        tiles = transparentPath.GetComponentsInChildren<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isVented)
        {
            if (doOnce == true)
            {
                doOnce = false;
                this.transform.position = new Vector3(transform.position.x, transform.position.y - 4, transform.position.z);
            }
            
            foreach(MeshRenderer t in tiles)
            {
                t.enabled = false;
            }
            
        }
        else
        {

            if (doOnce ==true)
            {
                doOnce = false;
                this.transform.position = new Vector3(transform.position.x, transform.position.y + 4, transform.position.z);
            }
            foreach (MeshRenderer t in tiles)
            {
                t.enabled = true;
            }
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
}
