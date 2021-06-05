using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "RPG Generator/Player/Skill")]


public class Skills : ScriptableObject
{
    public string Description;
    public Sprite Icon;
    public int LevelNeeded;
    public int XPNeeded;
    public List<PlayerAttributes> AffectedAttributes = new List<PlayerAttributes>();
    public int skillIndex;
    public List<Skills> SkillsToTurnOff;
    public bool turnOffSkills = false;

    public int energyIncreased;
    public bool canRegenerate;
    
    public void SetValues(GameObject SkillDisplayObject, PlayerStats Player)
    {
        if (Player)
        {
            CheckSkills(Player);
        }

        if (SkillDisplayObject)
        {
            SkillDisplay SD = SkillDisplayObject.GetComponent<SkillDisplay>();
            SD.skillName.text = name;

            if (SD.skillDescription)
            {
                SD.skillDescription.text = Description;
            }

            if (SD.skillIcon)
            {
                SD.skillIcon.sprite = Icon;
            }

            if (SD.skillLevel)
            {
                SD.skillLevel.text = LevelNeeded.ToString();
            }

            if (SD.skillXpNeeded)
            {
                SD.skillXpNeeded.text = XPNeeded.ToString();
            }

            if (SD.skillAttribute)
            {
                SD.skillAttribute.text = AffectedAttributes[0].attribute.ToString();
            }

            if (SD.skillAttrAmmount)
            {
                SD.skillAttrAmmount.text = AffectedAttributes[0].amount.ToString();
            }
        }
    }

    public bool CheckSkills(PlayerStats Player)
    {
        if (Player.PlayerLEvel < LevelNeeded)
        {
            return false;
        }

        if (Player.PLayerXP < XPNeeded)
        {
            return false;
        }

        return true;
    }

    public bool EnableSkill(PlayerStats Player)
    {
        List<Skills>.Enumerator skills = Player.PlayerSkills.GetEnumerator();
        while (skills.MoveNext())
        {
            var currSkill = skills.Current;
            if (currSkill.name == this.name)
            {

                return true;
            }
        }
        return false;

    }

    public bool GetSkill(PlayerStats Player)
    {
        int i = 0;
        List<PlayerAttributes>.Enumerator attributes = AffectedAttributes.GetEnumerator();
        while (attributes.MoveNext())
        {
            List<PlayerAttributes>.Enumerator PlayerAttrib = Player.Attributes.GetEnumerator();
            while (PlayerAttrib.MoveNext())
            {
                if (attributes.Current.attribute.name.ToString() == PlayerAttrib.Current.attribute.name.ToString())
                {
                    PlayerAttrib.Current.amount += attributes.Current.amount;
                    i++;
                }
            }

            if (i > 0)
            {

                Player.ActivateSkill(skillIndex);

                Player.energy += (int)energyIncreased;

               if(canRegenerate)
                {
                    Player.AllowRegen();
                }

                //turnOffSkills = true;
                DisableSkills();
                Player.PLayerXP -= this.XPNeeded;
                Player.UpdateLevel(1);
                Player.PlayerSkills.Add(this);
                return true;
            }
        }

        return false;
    }

    public bool DisableOtherSkills()
    {
        return turnOffSkills;
    }
    public void DisableSkills()
    {
        foreach(Skills s in SkillsToTurnOff)
        {
            s.turnOffSkills = true;
        }
    }
}
