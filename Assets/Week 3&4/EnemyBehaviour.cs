using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] Material normalColor;
    [SerializeField] Material boomColor;
    [SerializeField] Material damagedColor;

    NavMeshAgent enemy;
    MeshRenderer mr;

    bool reduce = false;
    bool detonate = false;

    float time;
    float initialSpeed;
    float boomTimer = 5f;

    float cycleTime = 1f;
    float auxCycle;
    Rigidbody rb;

    
    private void Awake()
    {
        enemy = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        initialSpeed = enemy.speed;
        mr = GetComponent<MeshRenderer>();
        auxCycle = cycleTime;
    }

    private void Update()
    {
       
        if (reduce)
        {
            if (time > 0f)
            {
                time -= Time.deltaTime;
            }
            else
            {
                enemy.speed = initialSpeed;
                reduce = false;
            }

        }

        if (detonate == true)
        {
            if (boomTimer > 0f)
            {
                auxCycle -= .1f*Time.deltaTime;
                boomTimer -= Time.deltaTime;
                float t = Time.time / auxCycle;
                t = Mathf.Abs((t - Mathf.Floor(t)) * cycleTime - 1);
                print(t);
                mr.material.color = Color.Lerp(normalColor.color, damagedColor.color, t);
            }
            else
            {
                Detonate();
                Destroy(this.gameObject);
            }
        }
    }
    public void TakeDamage(float damage)
    {
       
        health -= damage;
        if (health < 0)
        {
            Destroy(this.gameObject);
        }
        
    }

    public void ReduceSpeed(float amount, float period)
    {
        reduce = true;
        time = period;
        enemy.speed -= amount;
    }

    public void RemoteDetonate()
    {
        detonate = true;
    }


    void Detonate()
    {
        Collider[] allColliders = Physics.OverlapSphere(transform.position, 10f);
        foreach (Collider obj in allColliders)
        {
            Rigidbody objRb = obj.GetComponent<Rigidbody>();
            if (objRb != null)
            {
                objRb.AddExplosionForce(700f, transform.position, 10f);
                if (objRb.tag == "Player")
                {
                    objRb.gameObject.GetComponent<PlayerHealth>().TakeDamage(30f);
                }
                if (objRb.tag == "enemy")
                {
                    objRb.gameObject.GetComponent<EnemyBehaviour>().TakeDamage(15f);
                }
            }
        }
    }

    
    
}
