using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Skill : MonoBehaviour
{
    [SerializeField] bool RequirementLocked;
    [SerializeField] bool acquired;
    [SerializeField] bool hasLevels;
    [SerializeField] int maxNrOfLevels;

    [SerializeField] string Status;
    [SerializeField] int Price;
    [TextArea(1, 5)]
    [SerializeField] string Requirements;
    [TextArea(1, 5)]
    [SerializeField] string Description;
    [SerializeField] Image locked;

    Button skillButton;
    Color buttonColor;

    [SerializeField] GameObject descriptionPanel;
    [SerializeField] List<TextMeshProUGUI> panelTextFields;

    //private SkillTypes skills;

    // Start is called before the first frame update
    void Start()
    {
        skillButton = GetComponent<Button>();
       // skills = new SkillTypes();
    }

    // Update is called once per frame
    void Update()
    {
        if (acquired)
        {
            Status = "Unlocked";

            TryParseColor("#319A40");

        }
        else
        {
            Status = "Locked";

            TryParseColor("#FF1600");
        }

        if (RequirementLocked)
        {
            locked.gameObject.SetActive(true);
            skillButton.interactable = false;
        }
        else
        {
            locked.gameObject.SetActive(false);
            skillButton.interactable = true;

        }

        //AquireActive();
        //AquireD();
        //AquireE();
        //AquireA();
        //AquireB();
        //AquireC();
    }


    void TryParseColor(string _color)
    {
        ColorUtility.TryParseHtmlString(_color, out buttonColor);
        skillButton.GetComponent<Image>().color = buttonColor;

    }

    void ShowDescription()
    {
        panelTextFields[0].text = Status;
        panelTextFields[1].text = Price.ToString();

        panelTextFields[2].text = Description;
        if (RequirementLocked)
        {
            panelTextFields[3].text = Requirements;
        }
        else
        {
            panelTextFields[3].text = "N/A";
        }

    }
    public void OnhoverEnter()
    {
        descriptionPanel.SetActive(true);
        ShowDescription();
    }

    public void OnHoverExit()
    {
        descriptionPanel.SetActive(false);
    }

    public void Acquire()
    {
        PointSpending p = FindObjectOfType<PointSpending>();
        if (!acquired && p.GetFunds() > Price&&!RequirementLocked)
        {
            p.SpendFunds(Price);
            acquired = true;
        }

    }


    //public void AquireA()
    //{
    //    if (skills.TryUnlockSkill(SkillTypes.AllSkills.SkillA))
    //    {
    //        RequirementLocked = false;
    //    }

    //    if (skills.IsSkillUnlocked(SkillTypes.AllSkills.SkillA))
    //    {
    //        print("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
    //    }
    //    else print("BBBBBBBBBBBBBBBBBBB");
    //}
    //public void AquireB()
    //{
    //    if (skills.TryUnlockSkill(SkillTypes.AllSkills.SkillB))
    //    {
    //        RequirementLocked = false;
    //    }
    //}
    //public void AquireC()
    //{
    //    if (skills.TryUnlockSkill(SkillTypes.AllSkills.SkillC))
    //    {
    //        RequirementLocked = false;
    //    }
    //}
    //public void AquireD()
    //{
    //    if (skills.TryUnlockSkill(SkillTypes.AllSkills.SkillD))
    //    {
    //        RequirementLocked = false;
    //    }
    //}

    //public void AquireE()
    //{
    //    if (skills.TryUnlockSkill(SkillTypes.AllSkills.SkillE))
    //    {
    //        RequirementLocked = false;
    //    }


    //}

    //public void AquireActive()
    //{
    //    if (skills.TryUnlockSkill(SkillTypes.AllSkills.ActiveSkill))
    //    {
    //        RequirementLocked = false;
    //    }
    //}
}
