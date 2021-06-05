using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockSkill : MonoBehaviour

{
    [SerializeField] Image m_lock;
    UISkillTree manager;

    string ButtonName;

    // Start is called before the first frame update
    void Start()
    {
        manager = transform.parent.parent.GetComponent<UISkillTree>();
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
