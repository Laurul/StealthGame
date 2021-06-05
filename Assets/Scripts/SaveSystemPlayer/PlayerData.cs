using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float maxEnergy;
    public float maxHealth;
    public int XPpoints;
    public int defense;
    public int attribute1Mastery;
    public int attribute2Mastery;
    public int attribute3Mastery;
    public int level;
    public List<string> skillDescription = new List<string>();
    public List<string> EquippedAttackNames = new List<string>();
    public List<string> unlockedAttacksNames = new List<string>();
    public List<string> orderedAttacks = new List<string>();


    public PlayerData(PlayerContoller player, PlayerStats stats, ActiveAbilitySwapper playerAttacks, PlayerHudSwap hudDisplay)
    {
        this.maxEnergy = player.maxEnergy;
        this.maxHealth = player.maxHealth;
        this.XPpoints = stats.PLayerXP;
        this.defense = player.defense;
        this.attribute1Mastery = stats.Attributes[0].amount;
        this.attribute2Mastery = stats.Attributes[1].amount;
        this.attribute3Mastery = stats.Attributes[2].amount;
        this.level = stats.PlayerLEvel;

        foreach (Skills skillDes in stats.PlayerSkills)
        {
            bool ok = false;
            if (skillDescription.Count == 0)
            {
                skillDescription.Add(skillDes.Description);
            }
            else
            {
                foreach (string name in skillDescription)
                {
                    if (name == skillDes.Description)
                    {
                        ok = true;
                    }
                }
                if (ok == false)
                {
                    skillDescription.Add(skillDes.Description);
                }
            }

        }

        foreach (GameObject g in playerAttacks.currentActives)
        {
            bool ok = false;
            if (EquippedAttackNames.Count == 0)
            {
                EquippedAttackNames.Add(g.name);
            }
            else
            {
                foreach (string attackName in EquippedAttackNames)
                {
                    if (attackName == g.name)
                    {
                        ok = true;
                    }
                }
                if (ok == false)
                {
                    EquippedAttackNames.Add(g.name);
                }
            }



        }

        foreach (GameObject g in playerAttacks.allAvailableActives)
        {
            bool ok = false;
            if (unlockedAttacksNames.Count == 0)
            {
                unlockedAttacksNames.Add(g.name);
            }
            else
            {
                foreach (string unlockedAttack in unlockedAttacksNames)
                {
                    if (unlockedAttack == g.name)
                    {
                        ok = true;
                    }
                }
                if (ok == false)
                {
                    unlockedAttacksNames.Add(g.name);
                }
            }

        }
        foreach (GameObject g in hudDisplay.attackSlots)
        {
           
                orderedAttacks.Add(g.transform.GetChild(0).gameObject.name);
            
        }

    }

}
