using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class UISkillTree : MonoBehaviour
{
    public SkillTypes skills;
    [SerializeField] Image m_lock;
    Color buttonColor;
    [SerializeField] PointSpending wallet;
    [SerializeField] int defaultPrice;
    [SerializeField] int upgradedPrice;
    [SerializeField] int ActiveSkillPrice;
    private void Awake()
    {
        

        transform.Find("SkillA").GetComponent<Button>().onClick.AddListener(() => skills.TryUnlockSkill(SkillTypes.AllSkills.SkillA));
        transform.Find("SkillB").GetComponent<Button>().onClick.AddListener(() => skills.TryUnlockSkill(SkillTypes.AllSkills.SkillB));
        transform.Find("SkillC").GetComponent<Button>().onClick.AddListener(() => skills.TryUnlockSkill(SkillTypes.AllSkills.SkillC));
        transform.Find("SkillD").GetComponent<Button>().onClick.AddListener(() => skills.TryUnlockSkill(SkillTypes.AllSkills.SkillD));
        transform.Find("SkillE").GetComponent<Button>().onClick.AddListener(() => skills.TryUnlockSkill(SkillTypes.AllSkills.SkillE));
        transform.Find("SkillActive").GetComponent<Button>().onClick.AddListener(() => skills.TryUnlockSkill(SkillTypes.AllSkills.SkillActive));

       

    }
    private void Start()
    {
        
    }
    public void SetPlayerSkills(SkillTypes s)
    {
        skills = s;
       // skills.UnlockSkill(SkillTypes.AllSkills.SkillA);
    }

    private void Update()
    {

        CheckRequirement(SkillTypes.AllSkills.SkillA, defaultPrice);
        CheckRequirement(SkillTypes.AllSkills.SkillB, defaultPrice);
        CheckRequirement(SkillTypes.AllSkills.SkillC, defaultPrice);

        CheckRequirement(SkillTypes.AllSkills.SkillD, upgradedPrice);
        CheckRequirement(SkillTypes.AllSkills.SkillE, upgradedPrice);
        CheckRequirement(SkillTypes.AllSkills.SkillActive, ActiveSkillPrice);

        foreach (SkillTypes.AllSkills skill in Enum.GetValues(typeof(SkillTypes.AllSkills)))
        {
           

            string s = skill.ToString();
            if (skills.VerifyUnlockSkill(skill))
            {
              
                if (transform.Find(s) != null)
                {
                    transform.Find(s).Find("Lock").gameObject.SetActive(false);
                }
                 
            }
            if (skills.IsSkillUnloacked(skill))
            {
                TryParseColor("#319A40");
             
                if (transform.Find(s) != null)
                {
                    transform.Find(s).GetComponent<Image>().color = buttonColor;
                    transform.Find(s).GetComponent<Button>().interactable = false;
                }

            }
           
        }

        m_lock.rectTransform.anchoredPosition = m_lock.rectTransform.anchorMin;

        //bool isSkillDActive = skills.VerifyUnlockSkill(SkillTypes.AllSkills.SkillD);

        //if (isSkillDActive)
        //{
        //    transform.Find("SkillD").GetComponent<Button>().interactable = true;
        //    transform.Find("SkillD").Find("Lock").gameObject.SetActive(false);
        //}
        //else
        //{
        //    transform.Find("SkillD").GetComponent<Button>().interactable = false;
        //}


        //bool isSkillEActive = skills.VerifyUnlockSkill(SkillTypes.AllSkills.SkillE);
        //if (isSkillEActive)
        //{
        //    transform.Find("SkillE").GetComponent<Button>().interactable = true;
        //    transform.Find("SkillE").Find("Lock").gameObject.SetActive(false);

        //}
        //else
        //{
        //    transform.Find("SkillE").GetComponent<Button>().interactable = false;
        //}

        //bool isSkillActiveActive = skills.VerifyUnlockSkill(SkillTypes.AllSkills.SkillActive);
        //if (isSkillActiveActive)
        //{
        //    transform.Find("SkillActive").GetComponent<Button>().interactable = true;
        //    transform.Find("SkillActive").Find("Lock").gameObject.SetActive(false);
        //}
        //else
        //{
        //    transform.Find("SkillActive").GetComponent<Button>().interactable = false;
        //}

    }

    void CheckRequirement(SkillTypes.AllSkills s,int cost)
    {
        bool active= skills.VerifyUnlockSkill(s);
        if(wallet.GetFunds()<cost&&active)
        {
          
            transform.Find(s.ToString()).GetComponent<Button>().interactable = false;
        }
        else if (wallet.GetFunds() >= cost&&active)
        {
            
            transform.Find(s.ToString()).GetComponent<Button>().interactable = true;
        }

    }

    void TryParseColor(string _color)
    {
        ColorUtility.TryParseHtmlString(_color, out buttonColor);
        //skillButton.GetComponent<Image>().color = buttonColor;

    }

    public void SpendDefault()
    {
        wallet.SpendFunds(defaultPrice);
    }

    public void SpendUpgraded()
    {
        wallet.SpendFunds(upgradedPrice);
    }

    public void SpendActive()
    {
        wallet.SpendFunds(ActiveSkillPrice);
    }
}
