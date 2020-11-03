using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoTHis : MonoBehaviour
{
    HitScanGun gun;
    // Start is called before the first frame update
    void Start()
    {
        gun = GetComponent<HitScanGun>();
        //gun.ShootGun();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gun.ShootGun();
        }
    }

    
}
