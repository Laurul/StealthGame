﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SkillDisplay : MonoBehaviour
{
    public Skills skill;
    public Text skillName;
    public Text skillDescription;
    public Image skillIcon;
    public Text skillLevel;
    public Text skillXpNeeded;
    public Text skillAttribute;
    public Text skillAttrAmmount;

    [SerializeField] PlayerStats m_playerHandler;
    [SerializeField] Image disabledSkill;
    
    // Start is called before the first frame update
    void Start()
    {
       // m_playerHandler = this.GetComponentInParent<PlayerHandler>().Player;
        m_playerHandler.onXPChange += ReactToChange;
        m_playerHandler.onLevelChange += ReactToChange;


        if (skill)
        {
            skill.SetValues(this.gameObject, m_playerHandler);
        }
        
        EnableSkills();
        if (skill.turnOffSkills)
        {
            TurnOnSkillIcon();
        }
    }


    public void EnableSkills()
    {
        if (m_playerHandler && skill && skill.EnableSkill(m_playerHandler))
        {
            TurnOnSkillIcon();
        }

        else if (m_playerHandler && skill && skill.CheckSkills(m_playerHandler))
        {
            this.GetComponent<Button>().interactable = true;
            // this.transform.Find("IconParent").Find("Disabled").gameObject.SetActive(false);
            disabledSkill.gameObject.SetActive(false);
        }
        else
        {
            TurnOffSkillIcon();
        } 
    }

    private void OnEnable()
    {
        EnableSkills();
    }

    public void GetSkill()
    {
        if (skill.GetSkill(m_playerHandler))
        {
            TurnOnSkillIcon();
        }
    }

    private void TurnOnSkillIcon()
    {
        this.GetComponent<Button>().interactable = false;
        disabledSkill.gameObject.SetActive(true);
        //this.transform.Find("IconParent").Find("Available").gameObject.SetActive(false);
        // this.transform.Find("IconParent").Find("Disabled").gameObject.SetActive(false);
    }

    public void TurnOffSkillIcon()
    {
        this.GetComponent<Button>().interactable = false;
        disabledSkill.gameObject.SetActive(false);
        //this.transform.Find("IconParent").Find("Available").gameObject.SetActive(true);
        //this.transform.Find("IconParent").Find("Disabled").gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        m_playerHandler.onXPChange -= ReactToChange;
    }

    void ReactToChange()
    {
        EnableSkills();
    }

    public bool TurnOffSkill()
    {
        return skill.DisableOtherSkills();
        
    }

    public Skills RetrunDisplayedSkill()
    {
        return skill;
    }
}