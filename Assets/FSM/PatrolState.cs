using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PatrolState : IState
{
    public IState ActivateState(EnemyAI enemy)
    {
        if (enemy.navAgent == null)
        {
            enemy.navAgent = enemy.GetComponent<NavMeshAgent>();
        }


        PatrolArea(enemy);


        if (enemy.isIdle)
            return enemy.idle;
        else if (enemy.changeTarget==true)
            return enemy.chase;
        else return enemy.patrol;

    }

    private void PatrolArea(EnemyAI enemy)
    {
        enemy.navAgent.SetDestination(enemy.targets[enemy.index].position);
        if (HasReachedDestination(enemy))
        {
            if (enemy.index < enemy.targets.Length - 1)
            {
                enemy.index++;
                enemy.navAgent.destination = enemy.targets[enemy.index].position;
            }
            else
            {
                enemy.index = 0;
                enemy.navAgent.destination = enemy.targets[enemy.index].position;
            }
        }
    
    }

    private bool HasReachedDestination(EnemyAI enemy)
    {
        if (Vector3.Distance(enemy.navAgent.destination, enemy.navAgent.transform.position) <= enemy.navAgent.stoppingDistance)
        {

            if (!enemy.navAgent.hasPath || enemy.navAgent.velocity.sqrMagnitude == 0)
            {

                return true;

            }
        }

        return false;
    }
    
  
}
