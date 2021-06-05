using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RangeAttack :GenericAttack
{
    int AttackIndex;
    [SerializeField] Rigidbody cylinderPrefab;
    [SerializeField] GameObject activeIcon;
    [SerializeField] GameObject inactiveIcon;

    Rigidbody cylinderInstance;
    private new void Start()
    {
        AssignAttackIndex();
        base.Start();
    }
    private new void Update()
    {
        //print(this.transform.parent.name + "has attack index " + AttackIndex);
        base.Update();
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
    }
    public override void ExecuteAttack(int index)
    {
        
        if (index == AttackIndex&& energyBar.fillAmount >= 1.0f)
        {
            
            energyBar.fillAmount -= 1.0f;
            StartCoroutine("DoRangeAttack");
           
        }
    }

    IEnumerator DoRangeAttack()
    {
        Transform parent = playerReference.transform;
        GameObject instance = Instantiate(cloneToSpawn, playerReference.transform.position, parent.rotation);
        Animator instanceAnim = instance.GetComponent<Animator>();
        yield return new WaitForSeconds(2.5f);

        RaycastHit[] hits;
        Vector3 oldPos = instance.transform.position;
        instanceAnim.SetBool("DoRangedAttack", true);
        instance.transform.position += instance.transform.forward * Time.deltaTime * 400f;
        float dist = Vector3.Distance(oldPos, instance.transform.position);

        CreateCylinderBetweenPoints(oldPos, instance.transform.position, 2f);
        yield return new WaitForSeconds(0.5f);
        Destroy(cylinderInstance.gameObject);

        hits = Physics.RaycastAll(oldPos, instance.transform.forward, dist);

        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
           // print(hit.transform.name);
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

    void CreateCylinderBetweenPoints(Vector3 start, Vector3 end, float width)
    {
        Vector3 offset = end - start;
        Vector3 scale = new Vector3(width, offset.magnitude / 2.0f, width);
        Vector3 position = start + (offset / 2.0f);
        cylinderInstance = Instantiate(cylinderPrefab, position, Quaternion.identity);
        cylinderInstance.transform.up = offset;
        cylinderInstance.transform.localScale = scale;

    }

    void AssignAttackIndex()
    {
        if(this.transform.parent.name== "HeavyAttack")
        {
            AttackIndex = 1;
        }
        else if (this.transform.parent.name == "LightAttack")
        {
            AttackIndex = 2;
        }else if (this.transform.parent.name =="RangedAttack")
        {
            AttackIndex = 3;
        }
    }
}
