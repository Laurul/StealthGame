using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenericAttack : MonoBehaviour
{

    public virtual void ExecuteAttack(int index) { }

    [SerializeField]
    protected GameObject cloneToSpawn;

   [HideInInspector] public Animator cloneAnimator;

    public PlayerContoller playerReference;
    public float coolDownClone = 2.0f;
    public RuntimeAnimatorController cloneAnimController;
    [HideInInspector] public AnimatorOverrideController aoc;
    [HideInInspector] public float coolDown;
    [HideInInspector] public float cloneTriggerTime;
    [HideInInspector] public bool doOnce = false;
    [HideInInspector] public int index = 1;


   public Image energyBar;
    [HideInInspector] public float rechargeCooldown = 1f;

    public void Start()
    {


        cloneAnimator = cloneToSpawn.GetComponent<Animator>();
        cloneAnimator.runtimeAnimatorController = cloneAnimController;

        coolDown = coolDownClone;


        // aoc = new AnimatorOverrideController(cloneAnimator.runtimeAnimatorController);
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            index = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            index = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            index = 3;
        }
        

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
            doOnce = false;
        }
    }
}
