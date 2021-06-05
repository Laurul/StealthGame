using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetonate : MonoBehaviour
{
    EnemyBehaviour e;
    private void Awake()
    {
        e = GetComponentInParent<EnemyBehaviour>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            e.RemoteDetonate();
        }
    }
}
