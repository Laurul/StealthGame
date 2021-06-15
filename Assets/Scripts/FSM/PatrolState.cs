using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PatrolState : IState
{
   public bool chooseOnce = true;
  
    public IState ActivateState(EnemyAI enemy)
    {
        if (enemy.navAgent == null)
        {
            enemy.navAgent = enemy.GetComponent<NavMeshAgent>();
        }

       
        PatrolArea(enemy);


        //if (enemy.isIdle)
        //    return enemy.idle;
        //else if (enemy.changeTarget==true)
        //    return enemy.chase;
        //else return enemy.patrol;
        if (enemy.isIdle)
            return enemy.idle;
        else if (enemy.changeTarget == true)
        {
            enemy.chase.chooseOnce = true;
            return enemy.chase;
        }

        else if (enemy.changeTarget == false && enemy.isInvestigating == true)
        {
            enemy.investigate.chooseOnce = true;
            return enemy.investigate;
        }

        else
        {
           // enemy.patrol.chooseOnce = true;
            return enemy.patrol;
        }
    }

    private void PatrolArea(EnemyAI enemy)
    {
        enemy.navAgent.speed = 1.75f;
        if (enemy.UseRandomAnimation&&chooseOnce)
        {
            chooseOnce = false;
            enemy.randomAnim.RandomPatrolAnim();
        }
        enemy.enemyAnimator.SetBool("Idle", false);
        enemy.enemyAnimator.SetTrigger("FinishedInvestigation");
        enemy.navAgent.SetDestination(enemy.targets[enemy.allPaths[enemy.index]].position);
        if (HasReachedDestination(enemy))
        {
            int i = enemy.allPaths[enemy.index];
            Debug.Log(i);
            //if (enemy.index < enemy.targets.Length - 1)
            //{
            //    enemy.index++;
            //    enemy.navAgent.destination = enemy.targets[enemy.index].position;
            //}
            //else
            //{
            //    enemy.index = 0;
            //    enemy.navAgent.destination = enemy.targets[enemy.index].position;
            //}
            if (enemy.index < enemy.allPaths.Length-1)
            {
                enemy.index++;
                enemy.navAgent.destination = enemy.targets[enemy.allPaths[enemy.index]].position;
            }
            else
            {
                enemy.index = 0;
                enemy.navAgent.destination = enemy.targets[0].position;
            }
        }


                //make idle bool true at random times;
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
