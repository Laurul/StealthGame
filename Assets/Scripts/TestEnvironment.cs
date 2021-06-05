using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnvironment : MonoBehaviour
{
    [SerializeField] PointSpending p;
    [SerializeField] UISkillTree t;
    [SerializeField] GameObject SwapUi;
    // Start is called before the first frame update
    void Start()
    {
        t.SetPlayerSkills(p.GetCurrentSkills());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SwapUi.SetActive(!SwapUi.activeSelf);
        }
    }
}
