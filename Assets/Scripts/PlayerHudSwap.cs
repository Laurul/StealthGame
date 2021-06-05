using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHudSwap : MonoBehaviour
{
    public List<GameObject> attackSlots;
    public List<GameObject> attackContainers;
    

    private void Start()
    {
        attackContainers = new List<GameObject>();
        foreach (GameObject g in attackSlots)
        {
            if (g.transform.GetChild(0).tag == "AbilityContainer")
            {
                attackContainers.Add(g.transform.GetChild(0).gameObject);
            }

           
        }
       ;

        
    }

    private void Update()
    {
        //  print(attackContainers.Count);

    }
    public void SetAbilityPlacement(int position1, int position2)
    {
        print("NUMBER OF ATTACK CONTAINERS IS: "+attackContainers.Count);
        attackContainers[position1].transform.SetParent(attackSlots[position2].transform);
        attackContainers[position1].transform.localPosition = Vector3.zero;

        attackContainers[position2].transform.SetParent(attackSlots[position1].transform);
        attackContainers[position2].transform.localPosition = Vector3.zero;

        attackContainers.Clear();
        foreach (GameObject g in attackSlots)
        {
            if (g.transform.GetChild(0).tag == "AbilityContainer")
            {
                attackContainers.Add(g.transform.GetChild(0).gameObject);
            }
        }
        //container.transform.SetParent(attackSlots[position].transform);
        //container.transform.localPosition = Vector3.zero;
        //container.SetActive(true);
    }

}
