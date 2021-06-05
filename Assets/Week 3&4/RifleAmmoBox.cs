using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleAmmoBox : MonoBehaviour
{
    //Rifle playerRifle;
    [SerializeField] int amount = 5;
  
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerManager>().AddAmmoRifle(amount);
            Destroy(this.gameObject);
        }
    }
    //public string getRifle()
    //{
    //    return playerRifle.transform.parent.name;
    //}

    //public void setRifle(Rifle r)
    //{
    //    playerRifle = r;
    //}
}
