using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupManager : MonoBehaviour
{
    [SerializeField] GameObject pistolAmmoBox;
    [SerializeField] GameObject shotgunAmmoBox;
    [SerializeField] GameObject rifleAmmoBox;
    [SerializeField] GameObject healthPack;

    //[SerializeField] Pistol pistol;
    //[SerializeField] Shotgun shotgun;
    //[SerializeField] Rifle rifle;
    //[SerializeField] PlayerHealth playerHealth;

    int index = 4;
    float waitingTime = 4f;

    [SerializeField] List<Transform> spawnPoints;

    // Start is called before the first frame update
    void Awake()
    {
        //pistolAmmoBox.GetComponent<PistolAmmoBox>().setPistol(pistol);
        //shotgunAmmoBox.GetComponent<ShotgunAmmoBox>().setSHotgun(shotgun);
        //rifleAmmoBox.GetComponent<RifleAmmoBox>().setRifle(rifle);
        //healthPack.GetComponent<HealthPack>().setPlayer(playerHealth);

        foreach (Transform s in spawnPoints)
        {
            int i = Random.Range(0, 4);
            if (i == 0)
            {
                Instantiate(pistolAmmoBox, s.position,Quaternion.identity,s);
            }
            else if (i == 1)
            {
                Instantiate(shotgunAmmoBox, s.position, Quaternion.identity, s);
            }
            else if (i == 2)
            {
                Instantiate(rifleAmmoBox, s.position, Quaternion.identity, s);
            }
            else if (i == 3)
            {
                Instantiate(healthPack, s.position, Quaternion.identity, s);
            }
        }
    }

    private void Start()
    {
        StartCoroutine(PickupManagement());
    }


    void ReplacePickup(Transform t)
    {
        int i = Random.Range(0, 4);


        if (i == 0)
        {
            Instantiate(pistolAmmoBox, t.position, Quaternion.identity, t);
        }
        else if (i == 1)
        {
            Instantiate(shotgunAmmoBox, t.position, Quaternion.identity, t);
        }
        else if (i == 2)
        {
            Instantiate(rifleAmmoBox, t.position, Quaternion.identity, t);
        }
        else if (i == 3)
        {
            Instantiate(healthPack, t.position, Quaternion.identity,t);
        }



    }
    IEnumerator PickupManagement()
    {
        while (true)
        {
            yield return null;
            for (int i = 0; i < spawnPoints.Count; i++)
            {

                if (spawnPoints[i].childCount == 0)
                {

                    yield return new WaitForSeconds(4f);
                    ReplacePickup(spawnPoints[i]);


                }
            }
        }
    }
}
