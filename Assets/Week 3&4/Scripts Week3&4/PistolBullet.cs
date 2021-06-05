using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class PistolBullet : MonoBehaviour
{
    [SerializeField] float bulletDamage=20;
    [SerializeField] float timer=3f;

    private void Update()
    {
        if (timer > 0f)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "enemy")
        {
            other.GetComponent<EnemyBehaviour>().ReduceSpeed(0.5f, 3f);
            other.GetComponent<EnemyBehaviour>().TakeDamage(bulletDamage);
            
            Destroy(this.gameObject);
        }
        else if (other.tag == "wall")
        {
            Destroy(this.gameObject);
        }
     
    }
}
