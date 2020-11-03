using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitScanGun : MonoBehaviour
{
    [SerializeField] float damage = 10f;
    [SerializeField] float range = 100f;
    [SerializeField] float fireRate = 1.0f;
    bool fireAllowed = true;
    private WaitForSeconds shotDuration = new WaitForSeconds(0.07f);
    [HideInInspector] public bool allowedToFire = false;
    private float nextFire;
    private LineRenderer laserLine;
    [SerializeField] GameObject gunBarrel;
    [SerializeField] PlayerContoller player;
    // Start is called before the first frame update
    public void ShootGun()
    {
        // InvokeRepeating("Shoot", 0f, fireRate);
    }


    private void Start()
    {
        laserLine = GetComponent<LineRenderer>();

        //  InvokeRepeating("Shoot", 0f, fireRate);
    }
    // Update is called once per frame
    void Update()
    {
        if (allowedToFire == true && Time.time > nextFire)
        {
            laserLine.SetPosition(0, gunBarrel.transform.position);

            nextFire = Time.time + fireRate;

            StartCoroutine(ShotEffect());
            //  player.ReceiveDamage(damage);
            Vector3 relativePos = player.transform.position - transform.position;
            RaycastHit hit;
            if (Physics.Raycast(gunBarrel.transform.position, gunBarrel.transform.forward, out hit, range))
            {
                laserLine.SetPosition(1, hit.point);

                if (hit.transform != null)
                {
                    print(hit.transform.name);
                    PlayerContoller player = hit.transform.gameObject.GetComponent<PlayerContoller>();
                    if (player != null)
                        player.ReceiveDamage(damage);
                }
                else
                {
                    print("HITTING NOTHING!!!");
                }

            }

        }


    }



    public void Shoot()
    {

        RaycastHit hit;
        if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, range))
        {

            if (hit.transform != null)
            {
                print(hit.transform.name);
                hit.transform.gameObject.GetComponent<PlayerContoller>().ReceiveDamage(damage);
            }

        }



    }

    private IEnumerator ShotEffect()
    {
        yield return shotDuration;
    }
}
