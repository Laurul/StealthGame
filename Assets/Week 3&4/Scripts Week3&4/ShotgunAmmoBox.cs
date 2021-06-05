using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunAmmoBox : MonoBehaviour
{
    
    [SerializeField] int amount = 7;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerManager>().AddAmmoShotgun(amount);
            Destroy(this.gameObject);
        }
    }

    //public void setSHotgun(Shotgun s)
    //{
    //    playerShotgun= s;
    //}
}
