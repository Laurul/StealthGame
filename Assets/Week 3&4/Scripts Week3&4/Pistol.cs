using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    [SerializeField] GameObject pistolPrefab;
    [SerializeField] GameObject pistolBullet;
    [SerializeField] int ammoCapacity = 30;

    float fireRate = 0.15f;
    bool canShoot = true;
    GameObject pistol;
    Transform muzzle;
    private void Awake()
    {
        DisplayWeapon();
        muzzle = FindChild(pistol.transform, "Muzzle");
    }
    private void Update()
    {
        if (Input.GetMouseButton(0) && canShoot&&ammoCapacity>0)
        {
            Shoot();
        }
        
    }
    public override void DisplayWeapon()
    {
        pistol = Instantiate(pistolPrefab, transform.position, transform.rotation * Quaternion.Euler(0, 180f, 0));
        pistol.transform.SetParent(transform);
        pistol.transform.position += new Vector3(0f, 0f, 0.95f);
        

    }

    public override void Shoot()
    {
        StartCoroutine(FireRate());
    }

    IEnumerator FireRate()
    {
        canShoot = false;
        GameObject bullet = Instantiate(pistolBullet, muzzle.position, transform.rotation*Quaternion.Euler(90f,0f,0f));
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 1000f);
        ammoCapacity--;
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }

    public int RetrunCurrentAmmo()
    {
        return ammoCapacity;
    }
    public void AddAmmo(int ammount)
    {
        ammoCapacity += ammount;
    }

}
