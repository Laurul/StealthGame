using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : Weapon
{
    [SerializeField] GameObject riflePrefab;
    [SerializeField] GameObject rifleBullet;
    [SerializeField] int ammoCapacity = 7;
    GameObject rifle;
    Transform muzzle;


    float next = 0f;

    float fireRate = 1.0f;
    bool canShoot = true;
    private void Start()
    {

        DisplayWeapon();
        muzzle = FindChild(rifle.transform, "Muzzle");
    }
    private void Update()
    {
        if (ammoCapacity > 0)
        {
            Shoot();
        }

    }
    public override void DisplayWeapon()
    {
        rifle = Instantiate(riflePrefab, transform.position, transform.rotation * Quaternion.Euler(0, 180f, 0));

        rifle.transform.SetParent(transform);
        rifle.transform.localPosition += new Vector3(0f, 0f, 1.61f);
        rifle.transform.localScale = new Vector3(2f, 1f, 2f);

    }

    public override void Shoot()
    {
        if (Input.GetMouseButton(0) && Time.time > next)
        {
            GameObject bullet = Instantiate(rifleBullet, muzzle.position, transform.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 900f);
            ammoCapacity--;
            next = Time.time + fireRate;
        }
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
