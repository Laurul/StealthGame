using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IdleState : IState
{
    public IState ActivateState(EnemyAI enemy)
    {
        if (enemy.navAgent == null)
        {
            enemy.navAgent = enemy.GetComponent<NavMeshAgent>();
        }

        DoIdleMotion(enemy);
        if (enemy.changeTarget)
            return enemy.chase;
        else if (enemy.changeTarget == false && enemy.isIdle == false)
            return enemy.patrol;
        else
            return enemy.idle;
    }

    private void DoIdleMotion(EnemyAI enemy)
    {
        //enemy.navAgent.SetDestination(enemy.player.position);
    }
    
}
