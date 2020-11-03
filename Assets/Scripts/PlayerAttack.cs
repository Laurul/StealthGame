using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] GameObject heavyAttackActive;
    [SerializeField] GameObject heavyAttackInactive;
    [SerializeField] GameObject lightAttackActive;
    [SerializeField] GameObject lightAttackInactive;
    [SerializeField] GameObject rangedAttackActive;
    [SerializeField] GameObject rangedAttackInactive;

    [HideInInspector] public int index = 1;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
           
            index = 1;
            heavyAttackActive.SetActive(true);
            heavyAttackInactive.SetActive(false);
            lightAttackActive.SetActive(false);
            lightAttackInactive.SetActive(true);
            rangedAttackActive.SetActive(false);
            rangedAttackInactive.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) )
        {
           
            index = 2;
            heavyAttackActive.SetActive(false);
            heavyAttackInactive.SetActive(true);
            lightAttackActive.SetActive(true);
            lightAttackInactive.SetActive(false);
            rangedAttackActive.SetActive(false);
            rangedAttackInactive.SetActive(true);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3) )
        {
         
            index = 3;
            heavyAttackActive.SetActive(false);
            heavyAttackInactive.SetActive(true);
            lightAttackActive.SetActive(false);
            lightAttackInactive.SetActive(true);
            rangedAttackActive.SetActive(true);
            rangedAttackInactive.SetActive(false);
        }
       
    }
}
