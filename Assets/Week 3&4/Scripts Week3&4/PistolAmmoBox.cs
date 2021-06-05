using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolAmmoBox : MonoBehaviour
{
   //  Pistol playerPistol;
    [SerializeField] int amount = 7;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerManager>().AddAmmoPistol(amount);
            Destroy(this.gameObject);
        }
    }

    //public void setPistol(Pistol p)
    //{
    //    playerPistol = p;
    //}
}
