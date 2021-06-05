using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleBullet : MonoBehaviour
{
    [SerializeField] float bulletDamage = 80f;
    [SerializeField] float timer = 3.3f;

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
            
            other.GetComponent<Rigidbody>().AddForce(-other.transform.forward*10f, ForceMode.Impulse);//AddExplosionForce(1100f, transform.position, 5f);
            other.GetComponent<EnemyBehaviour>().TakeDamage(bulletDamage);

            Destroy(this.gameObject);
        }
        else if (other.tag == "wall")
        {
            Destroy(this.gameObject);
        }

    }
}
