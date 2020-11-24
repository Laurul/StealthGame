using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class AttackState : IState
{
    public bool chooseOnce = true;
    public IState ActivateState(EnemyAI enemy)
    {
        if (enemy.navAgent == null)
        {
            enemy.navAgent = enemy.GetComponent<NavMeshAgent>();
        }


        AttackTarget(enemy);

        if (enemy.inRange == true)
            return enemy.attack;
        else {
            enemy.chase.chooseOnce = true;
            return enemy.chase; }
    }

    private void AttackTarget(EnemyAI enemy)
    {
        if (enemy.UseRandomAnimation && chooseOnce)
        {
            chooseOnce = false;
            enemy.randomAnim.RandomAttackAnim();
        }
        enemy.enemyAnimator.SetBool("InRange", true);
        Vector3 relativePos = enemy.player.position - enemy.transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        enemy.transform.rotation = Quaternion.Slerp(enemy.transform.rotation, rotation, Time.deltaTime * 2.0f);
        //enemy.transform.LookAt(enemy.player);
        enemy.gun.allowedToFire = true;

    }
}
