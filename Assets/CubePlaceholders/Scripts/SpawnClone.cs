  using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SpawnClone : MonoBehaviour
{

    [SerializeField] GameObject cloneToSpawn;

    Animator playerAnimator;
    Animator cloneAnimator;

   
    [SerializeField] float coolDownClone = 2.0f;
    [SerializeField] RuntimeAnimatorController cloneAnimController;
    AnimatorOverrideController aoc;
    float coolDown;
    float cloneTriggerTime;
    bool doOnce = false;
   [HideInInspector] public int index = 1;


    [SerializeField] Image energyBar;
    float rechargeCooldown = 1f;



   [SerializeField] Rigidbody cylinderPrefab;

    Rigidbody cylinderInstance;
    void Start()
    {


        playerAnimator = GetComponent<Animator>();
        cloneAnimator = cloneToSpawn.GetComponent<Animator>();
        cloneAnimator.runtimeAnimatorController = cloneAnimController;

        coolDown = coolDownClone;


       // aoc = new AnimatorOverrideController(cloneAnimator.runtimeAnimatorController);
    }

    // Update is called once per frame
    void Update()
    {


        rechargeCooldown -= Time.deltaTime;
        if (energyBar.fillAmount < 1.0f && rechargeCooldown <= 0f)
        {
            energyBar.fillAmount += 0.03f;
            rechargeCooldown = 1f;
        }
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
        Animator instanceAnim = instance.GetComponent<Animator>();
        yield return new WaitForSeconds(1f);
        instance.transform.position += instance.transform.forward * Time.deltaTime *300f;
        RaycastHit[] objectsHit = Physics.SphereCastAll(instance.transform.position,2.0f, transform.forward);
        instanceAnim.SetBool("DoLightAttack", true);
        foreach (RaycastHit hit in objectsHit)
        {
            if (hit.transform.gameObject.tag == "enemy")
            {
                Destroy(hit.transform.gameObject);
            }
        }
        //instanceAnim.SetBool("DoLightAttack", false);
        yield return new WaitForSeconds(1.5f);
        Destroy(instance);


    }

    IEnumerator DoHeavyAttack()
    {
        Transform parent = this.transform;
        GameObject instance = Instantiate(cloneToSpawn, this.transform.position, parent.rotation);
        Animator instanceAnim = instance.GetComponent<Animator>();
        yield return new WaitForSeconds(3f);
        RaycastHit[] objectsHit = Physics.SphereCastAll(instance.transform.position, 4f, transform.forward);
        instanceAnim.SetBool("DoHeavyAttack", true);
        foreach (RaycastHit hit in objectsHit)
        {
            if (hit.transform.gameObject.tag == "enemy")
            {
                Destroy(hit.transform.gameObject);
            }
        }
       // instanceAnim.SetBool("DoHeavyAttack", false);
        yield return new WaitForSeconds(1.5f);
        Destroy(instance);
    }

    IEnumerator DoRangeAttack()
    {
        Transform parent = this.transform;
        GameObject instance = Instantiate(cloneToSpawn, this.transform.position, parent.rotation);
        Animator instanceAnim = instance.GetComponent<Animator>();
        yield return new WaitForSeconds(2.5f);
       
        RaycastHit[] hits;
        Vector3 oldPos = instance.transform.position;
        instanceAnim.SetBool("DoRangedAttack", true);
        instance.transform.position += instance.transform.forward * Time.deltaTime * 400f;
        float dist = Vector3.Distance(oldPos,instance.transform.position);

       CreateCylinderBetweenPoints(oldPos, instance.transform.position, 2f);
        yield return new WaitForSeconds(0.5f);
        Destroy(cylinderInstance.gameObject);

        hits = Physics.RaycastAll(oldPos, instance.transform.forward, dist);

        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            print(hit.transform.name);
            EnemyAI enemy = hit.transform.GetComponent<EnemyAI>();

            if (enemy)
            {
                Destroy(enemy);
            }
        }
        //instanceAnim.SetBool("DoRangedAttack", false);
        yield return new WaitForSeconds(1.5f);
        Destroy(instance);
       
    }



    void ExecuteAttack(int index)
    {
        if (index == 1 && energyBar.fillAmount == 1.0f)
        {
            energyBar.fillAmount -= 1.0f;
            StartCoroutine("DoHeavyAttack");
           
        }
        else if (index == 2 && energyBar.fillAmount >= 0.35f)
        {
            energyBar.fillAmount -= 0.35f;
            StartCoroutine("DoLightAttack");
        }
        else if (index == 3 && energyBar.fillAmount >= 0.6f)
        {
            energyBar.fillAmount -= 0.6f;
            StartCoroutine("DoRangeAttack");
        }
        
        doOnce = false;
    }





   void CreateCylinderBetweenPoints(Vector3 start, Vector3 end, float width)
    {
        Vector3 offset = end - start;
        Vector3 scale = new Vector3(width, offset.magnitude / 2.0f, width);
        Vector3 position = start + (offset / 2.0f);
        cylinderInstance = Instantiate(cylinderPrefab, position, Quaternion.identity);
        cylinderInstance.transform.up = offset;
        cylinderInstance.transform.localScale = scale;

    }
}

