using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    PlayerHealth player;
    float amount = 50f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerHealth>().AddHealth(amount);
            Destroy(this.gameObject);
        }
    }

    public void setPlayer(PlayerHealth p)
    {
        player = p;
    }
}
