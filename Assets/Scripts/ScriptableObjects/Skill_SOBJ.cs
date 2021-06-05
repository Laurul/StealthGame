using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public struct Skill_SOBJ
{
    public string skillName;
   
    public string description;

    public int cost;
    public List<string> unlockRequirements;

    public enum skillType {OneTimeBonus, Passive, Active, Environmantal}
    public skillType _skillType;

    public Skill_SOBJ(string _skillname, string _description, List<string> _unlockRequirements, int _cost, skillType _currentType)
    {
        this.skillName = _skillname;
        this.description = _description;
        this.unlockRequirements = _unlockRequirements;
        this.cost = _cost;
        this._skillType = _currentType;
    }
}
