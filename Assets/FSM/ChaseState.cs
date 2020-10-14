using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseState : IState
{
    public IState ActivateState(EnemyAI enemy)
    {
        if (enemy.navAgent == null)
        {
            enemy.navAgent = enemy.GetComponent<NavMeshAgent>();
        }
        ChaseAfterTarget(enemy);

        if (enemy.inRange)
            return enemy.attack;
        else if (enemy.changeTarget == false)
            return enemy.patrol;
        else return enemy.chase;
    }

    private void ChaseAfterTarget(EnemyAI enemy)
    {
        enemy.navAgent.destination=enemy.player.position;
    }
}
