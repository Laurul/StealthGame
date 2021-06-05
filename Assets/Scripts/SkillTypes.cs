using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SkillTypes
{
    public event EventHandler<OnSkillUnloackedEventArgs> OnSkillUnloacked;
    public class OnSkillUnloackedEventArgs : EventArgs
    {
        public AllSkills allSkills;
    }
    public enum AllSkills
    {
        None,
        SkillA,
        SkillB,
        SkillC,
        SkillD,
        SkillE,
        SkillActive,
    }

    private List<AllSkills> unlockedSkills;

    public SkillTypes()
    {
        unlockedSkills = new List<AllSkills>();
    }

    void UnlockSkill(AllSkills s)
    {
        if (!IsSkillUnloacked(s))
        {
            unlockedSkills.Add(s);
            OnSkillUnloacked?.Invoke(this, new OnSkillUnloackedEventArgs { allSkills = s });
        }

    }
    public bool IsSkillUnloacked(AllSkills s)
    {
        return unlockedSkills.Contains(s);
    }

    public AllSkills[] GEtSkillRequirement(AllSkills s)
    {
        AllSkills[] casePair = { AllSkills.None, AllSkills.None };
        switch (s)
        {

            case AllSkills.SkillE:
                {
                    casePair[0] = AllSkills.SkillC;
                    return casePair;
                }

            case AllSkills.SkillD:
                {
                    casePair[0] = AllSkills.SkillA;
                    casePair[1] = AllSkills.SkillB;
                    return casePair;
                }

            case AllSkills.SkillActive:
                {
                    if (IsSkillUnloacked(AllSkills.SkillE))
                    {
                        casePair[0] = AllSkills.SkillE;
                    }
                    else if (IsSkillUnloacked(AllSkills.SkillD))
                    {
                        casePair[0] = AllSkills.SkillD;
                    }
                    else
                    {
                        casePair[0] = AllSkills.SkillD;
                        casePair[1] = AllSkills.SkillE;
                    }
                    // return AllSkills.SkillD
                    return casePair;
                }
        }
        return casePair;
    }

    public bool TryUnlockSkill(AllSkills s)
    {

        AllSkills[] skillReq = GEtSkillRequirement(s);

        if (skillReq[0] != AllSkills.None && skillReq[1] != AllSkills.None)
        {
            if (IsSkillUnloacked(skillReq[0]) && IsSkillUnloacked(skillReq[1]))
            {
                UnlockSkill(s);
                return true;
            }
            else { return false; }
        }
        else if (skillReq[0] != AllSkills.None)
        {
            if (IsSkillUnloacked(skillReq[0]))
            {
                UnlockSkill(s);
                return true;
            }
            else { return false; }
        }
        else if (skillReq[1] != AllSkills.None)
        {
            if (IsSkillUnloacked(skillReq[1]))
            {
                UnlockSkill(s);
                return true;
            }
            else { return false; }
        }
       
        else
        {
            UnlockSkill(s);
            return true;
        }
    }


    public bool VerifyUnlockSkill(AllSkills s)
    {

        AllSkills[] skillReq = GEtSkillRequirement(s);

        if (skillReq[0] != AllSkills.None && skillReq[1] != AllSkills.None)
        {
            if (IsSkillUnloacked(skillReq[0]) && IsSkillUnloacked(skillReq[1]))
            {
                //UnlockSkill(s);
                return true;
            }
            else { return false; }
        }
        else if (skillReq[0] != AllSkills.None)
        {
            if (IsSkillUnloacked(skillReq[0]))
            {
               // UnlockSkill(s);
                return true;
            }
            else { return false; }
        }
        else if (skillReq[1] != AllSkills.None)
        {
            if (IsSkillUnloacked(skillReq[1]))
            {
                UnlockSkill(s);
                return true;
            }
            else { return false; }
        }

        else
        {
           // UnlockSkill(s);
            return true;
        }
    }
}
