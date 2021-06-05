using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] ChangeWeapons playerWeapons;
    [SerializeField] Pistol playerPistol;
    [SerializeField] Shotgun playerShotgun;
    [SerializeField] Rifle playerRifle;
    bool switchedPistol = false;
    bool switchedShotgun = false;
    bool switchedRifle = false;

    // Update is called once per frame
    void Update()
    {


        if (switchedPistol && switchedRifle && switchedShotgun)
        {

           // print("FIND MORE AMMO");

            if (playerPistol.RetrunCurrentAmmo() != 0)
            {
                playerWeapons.NextWeapon(0);
                switchedPistol = false;
            }
            else if (playerShotgun.RetrunCurrentAmmo() != 0)
            {
                playerWeapons.NextWeapon(1);
                switchedShotgun = false;
            }

            else if (playerRifle.RetrunCurrentAmmo() != 0)
            {
                playerWeapons.NextWeapon(2);
                switchedRifle = false;
            }
        }
        else
        {
           // print("HAS AMMO");

            if (playerPistol.RetrunCurrentAmmo() == 0 && switchedPistol == false)
            {
                playerWeapons.NextWeapon(playerWeapons.returnCurrentIndex());
                switchedPistol = true;
            }


            if (playerShotgun.RetrunCurrentAmmo() == 0 && switchedShotgun == false)
            {
                playerWeapons.NextWeapon(playerWeapons.returnCurrentIndex());
                switchedShotgun = true;
            }


            if (playerRifle.RetrunCurrentAmmo() == 0 && switchedRifle == false)
            {
                playerWeapons.NextWeapon(playerWeapons.returnCurrentIndex());
                switchedRifle = true;
            }

        }

    }
}
