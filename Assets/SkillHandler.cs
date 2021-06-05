using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SkillHandler : MonoBehaviour
{
    [SerializeField] List<SkillDisplay> gameSkills;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < gameSkills.Count; i++)
        {
            CheckDisableSkill(gameSkills[i]);
        }
    }

    void CheckDisableSkill(SkillDisplay sd)
    {
        // print(sd.gameObject.name + sd.TurnOffSkill());
        if (sd.TurnOffSkill() == true)
        {
            List<Skills> skillsToBeAffected = sd.RetrunDisplayedSkill().SkillsToTurnOff;
            foreach (SkillDisplay s in gameSkills)
            {
                for (int i = 0; i < skillsToBeAffected.Count; i++)
                {
                    if (s.RetrunDisplayedSkill().name == skillsToBeAffected[i].name&&s!=sd)
                    {
                        s.TurnOffSkillIcon();
                        
                    }
                }

            }
        }
    }
}
