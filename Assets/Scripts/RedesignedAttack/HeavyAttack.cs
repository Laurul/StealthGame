using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyAttack : GenericAttack
{
    [SerializeField] GameObject activeIcon;
    [SerializeField] GameObject inactiveIcon;
    int AttackIndex;
    private new void Start()
    {
        AssignAttackIndex();
        base.Start();
    }
    private new void Update()
    {
        //print(this.transform.parent.name + "has attack index " + AttackIndex);
        if (index == AttackIndex)
        {
            activeIcon.SetActive(true);
            inactiveIcon.SetActive(false);
        }
        else
        {
            inactiveIcon.SetActive(true);
            activeIcon.SetActive(false);
        }
        base.Update();
    }
    public override void ExecuteAttack(int index)
    {
       
        if (index == AttackIndex && energyBar.fillAmount >= 1.0f)
        {
           
            energyBar.fillAmount -= 1.0f;
            StartCoroutine("DoHeavyAttack");
           
        }
    }

    IEnumerator DoHeavyAttack()
    {
        Transform parent = playerReference.transform;
        GameObject instance = Instantiate(cloneToSpawn, playerReference.transform.position, parent.rotation);
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

    void AssignAttackIndex()
    {
        if (this.transform.parent.name == "HeavyAttack")
        {
            AttackIndex = 1;
        }
        else if (this.transform.parent.name == "LightAttack")
        {
            AttackIndex = 2;
        }
        else if (this.transform.parent.name == "RangedAttack")
        {
            AttackIndex = 3;
        }
    }
}
