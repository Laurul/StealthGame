using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IdleState : IState
{
    bool chooseOnce=true;
    public IState ActivateState(EnemyAI enemy)
    {
        if (enemy.navAgent == null)
        {
            enemy.navAgent = enemy.GetComponent<NavMeshAgent>();
        }

        DoIdleMotion(enemy);
        if (enemy.changeTarget)
        {
            enemy.chase.chooseOnce = true;
            return enemy.chase;
        }
            
        else if (enemy.changeTarget == false && enemy.isIdle == false)
        {
            enemy.patrol.chooseOnce = true;
            return enemy.patrol;
        }
           
        else
            return enemy.idle;
    }

    private void DoIdleMotion(EnemyAI enemy)
    {
        if (enemy.UseRandomAnimation && chooseOnce)
        {
            chooseOnce = false;
            enemy.randomAnim.RandomIdleAnim();
        }
        enemy.navAgent.SetDestination(enemy.transform.position);
        //enemy.navAgent.SetDestination(enemy.player.position);
        //do idle bool false as soon as you finish the idle animation
    }
    
}
