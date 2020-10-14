using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitScanGun : MonoBehaviour
{
    [SerializeField] float damage = 10f;
    [SerializeField] float range = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        RaycastHit hit;
       if( Physics.Raycast(this.transform.position, this.transform.forward, out hit, range))
        {
            hit.transform.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }
}
