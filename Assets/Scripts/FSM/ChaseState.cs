using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseState : IState
{
    public bool chooseOnce = true;
    public IState ActivateState(EnemyAI enemy)
    {
        if (enemy.navAgent == null)
        {
            enemy.navAgent = enemy.GetComponent<NavMeshAgent>();
        }

        ChaseAfterTarget(enemy);

        if (enemy.inRange == true)
        {
            enemy.attack.chooseOnce = true;
            return enemy.attack;
        }
           
        else if (enemy.changeTarget == false)
        {
            enemy.investigate.chooseOnce = true;
            return enemy.investigate;
        }
           
        else return enemy.chase;

        //  else if (enemy.isInvestigating==true)//||enemy.player==null)// if (enemy.changeTarget == false||enemy.player==null)->patrol
        //return enemy.investigate;
    }

    private void ChaseAfterTarget(EnemyAI enemy)
    {

        if (enemy.UseRandomAnimation&&chooseOnce)
        {
            chooseOnce = false;
            enemy.randomAnim.RandomChaseAnim();
        }
        enemy.gun.allowedToFire = false;
        enemy.navAgent.speed = 2.0f;
        enemy.enemyAnimator.SetBool("EnemySpotted", true);
        enemy.enemyAnimator.SetBool("InRange", false);
        if(enemy.player != null)
        enemy.navAgent.destination=enemy.player.position;
    }
}
