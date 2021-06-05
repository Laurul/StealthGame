using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayPlayerStats : MonoBehaviour
{
    [SerializeField] Text currentHealth;
    [SerializeField] Text maxHealth;
    [SerializeField] Text currentEnergy;
    [SerializeField] Text maxEnergy;
    [SerializeField] PlayerStats player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth.text = player.health.ToString();
        maxHealth.text = player.maxHealth.ToString();

        currentEnergy.text = player.energy.ToString();
        maxEnergy.text = player.maxEnergy.ToString();
    }
}
