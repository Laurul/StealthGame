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
    bool doOnce = false;
   [HideInInspector] public int index = 1;
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



        if (Input.GetMouseButtonDown(0))
        {
            doOnce = true;
        }

        if (doOnce)
        {

            ExecuteAttack(index);
        }

        //GameObject g = cloneToSpawn;
        //coolDown -= Time.deltaTime;
        //if (Input.GetKeyDown(KeyCode.E)&&coolDown<=0)
        //{ 
        //    Instantiate(cloneToSpawn, transform.position, Quaternion.identity);
        //    playerAnimator.SetTrigger("StartSpin");


        //    coolDown = coolDownClone;
        //}


        //if (anim)
        //{
        //    cloneAnimator.SetTrigger("StatTransition");
        //    var anims = new List<KeyValuePair<AnimationClip, AnimationClip>>();
        //    foreach (var a in aoc.animationClips)
        //        anims.Add(new KeyValuePair<AnimationClip, AnimationClip>(a, anim));

        //    aoc.ApplyOverrides(anims);

        //    cloneAnimator.runtimeAnimatorController = aoc; 
        //}


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

    IEnumerator DoLightAttack()
    {
        Transform parent = this.transform;
        GameObject instance = Instantiate(cloneToSpawn, this.transform.position, parent.rotation);

        yield return new WaitForSeconds(1f);
        instance.transform.position += instance.transform.forward * Time.deltaTime * 200f;
        RaycastHit[] objectsHit = Physics.SphereCastAll(instance.transform.position, 2.5f, transform.forward);

        foreach (RaycastHit hit in objectsHit)
        {
            if (hit.transform.gameObject.tag == "enemy")
            {
                Destroy(hit.transform.gameObject);
            }
        }

        yield return new WaitForSeconds(1.5f);
        Destroy(instance);


    }

    IEnumerator DoHeavyAttack()
    {
        Transform parent = this.transform;
        GameObject instance = Instantiate(cloneToSpawn, this.transform.position, parent.rotation);
        yield return new WaitForSeconds(3f);
        RaycastHit[] objectsHit = Physics.SphereCastAll(instance.transform.position, 4f, transform.forward);

        foreach (RaycastHit hit in objectsHit)
        {
            if (hit.transform.gameObject.tag == "enemy")
            {
                Destroy(hit.transform.gameObject);
            }
        }
        yield return new WaitForSeconds(1.5f);
        Destroy(instance);
    }

    public void DoRangeAttack()
    {
        Instantiate(cloneToSpawn, transform.position, Quaternion.identity);
    }



    void ExecuteAttack(int index)
    {
        if (index == 1)
        {
            StartCoroutine("DoLightAttack");
        }
        else if (index == 2)
        {
            StartCoroutine("DoHeavyAttack");
        }
        else if (index == 3)
        {
            StartCoroutine("DoRangeAttack");
        }
        doOnce = false;
    }
}

