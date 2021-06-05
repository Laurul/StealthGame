using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] Pistol p;
    [SerializeField] Shotgun s;
    [SerializeField] Rifle r;
    public void AddAmmoPistol(int amount)
    {
        p.AddAmmo(amount);
    }

    public void AddAmmoShotgun(int amount)
    {
        s.AddAmmo(amount);
    }

    public void AddAmmoRifle(int amount)
    {
        r.AddAmmo(amount);
    }


    public int returnPistolAmmo()
    {
        return p.RetrunCurrentAmmo();
    }
    public int returnShotgunAmmo()
    {
        return s.RetrunCurrentAmmo();
    }

    public int returnRifleAmmo()
    {
        return r.RetrunCurrentAmmo();
    }
}
