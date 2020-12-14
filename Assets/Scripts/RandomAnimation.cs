using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAnimation : MonoBehaviour
{
    [SerializeField] List<AnimationClip> IdleClips;
    [SerializeField] List<AnimationClip> WalkingClips;
    [SerializeField] List<AnimationClip> ChasingClips;
    [SerializeField] List<AnimationClip> AttackClips;
    [SerializeField] List<AnimationClip> InvestigateClips;
    //  [SerializeField] List<AnimationClip> DeathClips;

    AnimatorOverrideController aoc;
    Animator enemyAnimator;
    // Start is called before the first frame update
    void Start()
    {
        enemyAnimator = GetComponent<Animator>();
        aoc = new AnimatorOverrideController(enemyAnimator.runtimeAnimatorController);
        enemyAnimator.runtimeAnimatorController = aoc;
    }

    public void RandomIdleAnim()
    {
        int i = Random.Range(0, IdleClips.Count);
        aoc["Idle Rifle"] = IdleClips[i];

    }
    public void RandomPatrolAnim()
    {
        int j = Random.Range(0, WalkingClips.Count);
        aoc["Walk Rifle"] = WalkingClips[j];
        //patrol
        enemyAnimator.SetBool("Idle", false);
        enemyAnimator.SetTrigger("FinishedInvestigation");
    }
    public void RandomChaseAnim()
    {
        int k = Random.Range(0, ChasingClips.Count);
        aoc["Run Rifle"] = ChasingClips[k];
        //chase

        enemyAnimator.SetBool("EnemySpotted", true);
        enemyAnimator.SetBool("InRange", false);

    }
    public void RandomAttackAnim()
    {
        int l = Random.Range(0, AttackClips.Count);
        aoc["Fire SniperRifle"] = AttackClips[l];

        //attack
        enemyAnimator.SetBool("InRange", true);

    }
    public void RandomInvestigateAnim()
    {

        int m = Random.Range(0, InvestigateClips.Count);
        aoc["Wary Rifle"] = InvestigateClips[m];
        //investigate
        enemyAnimator.SetBool("EnemySpotted", false);
        enemyAnimator.ResetTrigger("FinishedInvestigation");
    }

}
