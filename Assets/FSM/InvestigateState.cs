using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InvestigateState : IState
{
    public bool chooseOnce = true;
    public IState ActivateState(EnemyAI enemy)
    {
        if (enemy.navAgent == null)
        {
            enemy.navAgent = enemy.GetComponent<NavMeshAgent>();
        }


        InvestigateArea(enemy);


        if (enemy.changeTarget == true)
        {
            enemy.chase.chooseOnce = true;
            return enemy.chase;
        }

        else if (enemy.isInvestigating == false)
        {
            enemy.patrol.chooseOnce = true;
            return enemy.patrol;
        }

        else
        {
           // enemy.investigate.chooseOnce = true;
            return enemy.investigate;
        }
    }

    private void InvestigateArea(EnemyAI enemyAI)
    {
        if (enemyAI.UseRandomAnimation && chooseOnce)
        {
            enemyAI.randomAnim.RandomInvestigateAnim();
            chooseOnce = false;
        }
        enemyAI.enemyAnimator.SetBool("EnemySpotted", false);
        enemyAI.enemyAnimator.ResetTrigger("FinishedInvestigation");

        Vector3 patrolPos = new Vector3(enemyAI.gameObject.transform.position.x + 5, enemyAI.gameObject.transform.position.y, enemyAI.gameObject.transform.position.z);
        enemyAI.navAgent.SetDestination(patrolPos);
    }
}
