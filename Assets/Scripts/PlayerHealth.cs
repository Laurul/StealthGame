using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float health = 100f;

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health < 0)
        {
            Destroy(this.gameObject);
        }
    }
    public void AddHealth(float amount)
    {
        if (health < 200f)
        {
            health += amount;
        }
       else
        {
            health = 200f;
        }
    }
}
