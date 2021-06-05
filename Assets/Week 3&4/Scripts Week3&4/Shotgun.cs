using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    [SerializeField] GameObject shotgunPrefab;
    [SerializeField] GameObject shotgunPellets;
    [SerializeField] int amount;
    [SerializeField] int ammoCapacity = 15;

    float fireRate = 1.5f;

    float next = 0f;

    GameObject shotgun;
    Transform muzzle;

    float spread = 0.5f;
    private void Awake()
    {
        DisplayWeapon();
        muzzle = FindChild(shotgun.transform, "Muzzle");
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

        shotgun = Instantiate(shotgunPrefab, transform.position, transform.rotation * Quaternion.Euler(0, 180f, 0));
        //shotgun.transform.position += new Vector3(0f, 0f, 1.61f);
       
        shotgun.transform.SetParent(transform);
        shotgun.transform.localPosition += new Vector3(0f, 0f, 1.61f);
    }

    public override void Shoot()
    {
        if (Input.GetMouseButton(0) && Time.time > next)
        {
            for(int i = 0; i < amount; i++)
            {   
                GameObject pellet = Instantiate(shotgunPellets,muzzle.position ,Quaternion.identity);

                pellet.GetComponent<Rigidbody>().AddForce((transform.forward  + new Vector3(Random.Range(-spread, spread), 0f)) * 375f);              
            }
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
