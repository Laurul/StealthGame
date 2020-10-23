using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class AttackState : IState
{
    public IState ActivateState(EnemyAI enemy)
    {
        if (enemy.navAgent == null)
        {
            enemy.navAgent = enemy.GetComponent<NavMeshAgent>();
        }
        AttackTarget(enemy);

        if (enemy.inRange==true)
            return enemy.attack;
        else return enemy.chase;
    }

    private void AttackTarget(EnemyAI enemy)
    {
      
        enemy.enemyAnimator.SetBool("InRange", true);
        enemy.transform.LookAt(enemy.player);
        enemy.gun.ShootGun();
       
    }
}
