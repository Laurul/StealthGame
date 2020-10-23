using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitScanGun : MonoBehaviour
{
    [SerializeField] float damage = 10f;
    [SerializeField] float range = 100f;
    [SerializeField] float fireRate = 1.0f;
    bool fireAllowed = true;
    // Start is called before the first frame update
    public void ShootGun()
    {
        InvokeRepeating("Shoot", 0f, fireRate);
    }


    private void Start()
    {
      //  InvokeRepeating("Shoot", 0f, fireRate);
    }
    // Update is called once per frame
    void Update()
    {


    }



    void Shoot()
    {
        
        RaycastHit hit;
        if (Physics.Raycast(this.transform.position, this.transform.forward, out hit,range))
        {

            if (hit.transform != null)
            {
                print(hit.transform.name);
                hit.transform.gameObject.GetComponent<PlayerContoller>().ReceiveDamage(damage);
            }

        }
        

    }
}
