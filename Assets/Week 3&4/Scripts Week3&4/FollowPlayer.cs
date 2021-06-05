using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    NavMeshAgent enemyAgent;
    Transform target;
    [SerializeField] bool follow = true;
    private void Start()
    {
        target = Object.FindObjectOfType<PlayerHealth>().transform;
        enemyAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if(follow)
        enemyAgent.SetDestination(target.position);
    }
}
