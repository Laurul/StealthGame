using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;


public class SpawnClone : MonoBehaviour
{
   
    [SerializeField] GameObject cloneToSpawn;
   
    Animator playerAnimator;
    Animator cloneAnimator;

    [SerializeField] AnimationClip anim;
    [SerializeField] float coolDownClone = 2.0f;
    [SerializeField] AnimatorController c;
    AnimatorOverrideController aoc;
    float coolDown;
    float cloneTriggerTime;

    void Start()
    {
     
        
        playerAnimator = GetComponent<Animator>();
        cloneAnimator = cloneToSpawn.GetComponent<Animator>();
        cloneAnimator.runtimeAnimatorController = c;
     
        coolDown = coolDownClone;


        aoc = new AnimatorOverrideController(cloneAnimator.runtimeAnimatorController);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject g = cloneToSpawn;
        coolDown -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.E)&&coolDown<=0)
        { 
            Instantiate(cloneToSpawn, transform.position, Quaternion.identity);
            playerAnimator.SetTrigger("StartSpin");

           
            coolDown = coolDownClone;
        }


        if (anim)
        {
            cloneAnimator.SetTrigger("StatTransition");
            var anims = new List<KeyValuePair<AnimationClip, AnimationClip>>();
            foreach (var a in aoc.animationClips)
                anims.Add(new KeyValuePair<AnimationClip, AnimationClip>(a, anim));

            aoc.ApplyOverrides(anims);

            cloneAnimator.runtimeAnimatorController = aoc; 
        }


    }

    public void SetAnimations(AnimatorOverrideController cont, int index)
    {
        //    AnimatorOverrideController aoc = new AnimatorOverrideController(cloneAnimator.runtimeAnimatorController);
        //    var anims = new List<KeyValuePair<AnimationClip, AnimationClip>>();
        //    foreach (var a in aoc.animationClips)
        //        anims.Add(new KeyValuePair<AnimationClip, AnimationClip>(a, anim));
        //    aoc.ApplyOverrides(anims);


        //   // cloneAnimator.runtimeAnimatorController = cont;
        //    Instantiate(cloneToSpawn,transform.position,Quaternion.identity);
    }
}
