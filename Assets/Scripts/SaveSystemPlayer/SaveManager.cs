using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public List<Skills> allSkills;
    public List<GameObject> allAttacks;
    public PlayerStats playerStats;
    public PlayerContoller playerController;
    public ActiveAbilitySwapper swapper;
    public PlayerHudSwap attackHUD;
    // Start is called before the first frame update
    void Start()
    {
        LoadData();
    }

    public void SaveData()
    {
        SaveSystem.SavePlayer(playerController, playerStats, swapper, attackHUD);
    }

    public void LoadData()
    {

        PlayerData data = SaveSystem.LoadPlayer();
        playerStats.maxEnergy = (int)data.maxEnergy;
        playerStats.maxHealth = (int)data.maxHealth;
        playerStats.PLayerXP += data.XPpoints;
        playerController.defense = data.defense;
        playerStats.Attributes[0].amount = data.attribute1Mastery;
        playerStats.Attributes[1].amount = data.attribute2Mastery;
        playerStats.Attributes[2].amount = data.attribute3Mastery;
        playerStats.PlayerLEvel = data.level;

        foreach (string des in data.skillDescription)
        {
            foreach (Skills skill in allSkills)
            {
                if (des == skill.Description)
                {
                    //playerStats.PlayerSkills.Add(skill);
                    skill.GetSkill(playerStats);
                    //skill.turnOffSkills = true;
                }
            }
        }

        swapper.allAvailableActives.Clear();
        foreach (string allAttacksName in data.unlockedAttacksNames)
        {
            foreach (GameObject g in allAttacks)
            {
                if (allAttacksName == g.name)
                {
                    swapper.allAvailableActives.Add(g);

                }

            }
        }


        for (int i = 0; i < 3; i++)
        {
            swapper.currentActives.SetValue(null, i);

        }
        int j = 0;

        //foreach (string equippedAttackName in data.EquippedAttackNames)
        //{
        //    foreach (GameObject g in allAttacks)
        //    {
        //        if (equippedAttackName == g.name)
        //        {
        //            swapper.currentActives.SetValue(g, j);
        //            j++;
        //        }


        //    }

        //}

        int k = 0;
        foreach (string order in data.orderedAttacks)
        {
            foreach (GameObject g in allAttacks)
            {
                if (order == g.name && k <= 3)
                {
                    if (j < 3)
                    {
                        swapper.currentActives.SetValue(g, j);
                        j++;
                    }
                   
                    g.transform.SetParent(attackHUD.attackSlots[k].transform);
                    g.transform.localPosition = Vector3.zero;
                    k++;

                    
                }
            }

            //else
            //{
            //    g.transform.SetParent(attackHUD.attackSlots[k].transform);
            //    g.transform.localPosition = Vector3.zero;
            //}
        }

    }
}
