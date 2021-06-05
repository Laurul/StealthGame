using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunBullet : MonoBehaviour
{
    [SerializeField] float pelletDamage = 10;
    [SerializeField] float timer = 1.2f;

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
            other.GetComponent<EnemyBehaviour>().RemoteDetonate();
            other.GetComponent<EnemyBehaviour>().TakeDamage(pelletDamage);

            Destroy(this.gameObject);
        }
        else if (other.tag == "wall")
        {
            Destroy(this.gameObject);
        }

    }
}
