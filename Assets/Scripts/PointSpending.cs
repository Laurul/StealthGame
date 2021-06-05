using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSpending : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int funds;
    [SerializeField] GameObject activeSkillContainer;
    [SerializeField] ActiveAbilitySwapper swapper;
   
    private SkillTypes playerSkills;
    [SerializeField] List<GameObject> containers;
    [SerializeField] List<string> words;
    Dictionary<GameObject, string> containerValues;
    private int hp = 100;




    [SerializeField] List<GameObject> skills;
  


    private void Awake()
    {
       
   
        containerValues = new Dictionary<GameObject, string>();
        for(int i = 0; i < containers.Count; i++)
        {
            containerValues.Add(containers[i], words[i]);
        }
        playerSkills = new SkillTypes();
        playerSkills.OnSkillUnloacked += PlayerSkills_OnSkillsUnlocked;
    }
    public void SpendFunds(int price)
    {
        funds -= price;
    }

    public int GetFunds()
    {
        return funds;
    }

    public void AddFunds(int sum)
    {
        funds += sum;
    }

    private void Update()
    {

        foreach (GameObject g in skills)
        {
           GameObject t = g.GetComponentsInChildren<Transform>()[1].gameObject;
            // print(containerValues[child]);
           // if (child != null)
                print(containerValues[t]);

        }
        //for(int i = 0; i < containerValues.Count; i++)
        //{
        //    print(containerValues[containers[i]]);
        //}
        // Debug.Log("MONEY: "+GetFunds());
        // Debug.Log("HP "+hp);
    }

    public SkillTypes GetCurrentSkills()
    {
        return playerSkills;
    }

    private void PlayerSkills_OnSkillsUnlocked(object sender, SkillTypes.OnSkillUnloackedEventArgs e)
    {
        switch (e.allSkills)
        {
            case SkillTypes.AllSkills.SkillA:
                //SET PLAYER HEALTH
                hp = 110;
                break;
            case SkillTypes.AllSkills.SkillB:
                //SET PLAYER HEALTH
                hp = 120;
                break;
            case SkillTypes.AllSkills.SkillC:
                //SET PLAYER HEALTH
                hp = 130;
                break;
            case SkillTypes.AllSkills.SkillD:
                //SET PLAYER HEALTH
                hp = 140;
                break;
            case SkillTypes.AllSkills.SkillE:
                //SET PLAYER HEALTH
                hp = 150;
                break;
            case SkillTypes.AllSkills.SkillActive:
                swapper.AddToList(activeSkillContainer);
                //SET NEW PLAYER ABILITY
                break;
        }
    }
}
