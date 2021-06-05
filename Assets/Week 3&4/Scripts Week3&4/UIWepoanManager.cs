using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIWepoanManager : MonoBehaviour
{
    ChangeWeapons playerWeapons;
    [SerializeField] List<GameObject> weaponUI;
    [SerializeField] List<Text> ammoCounters;
    [SerializeField] PlayerManager player;

    int Currentindex = -1;
    int index;
    void Start()
    {
        playerWeapons = GameObject.FindObjectOfType<ChangeWeapons>();
    }

    // Update is called once per frame
    void Update()
    {
        ammoCounters[0].text = player.returnPistolAmmo().ToString();
        ammoCounters[1].text = player.returnShotgunAmmo().ToString();
        ammoCounters[2].text = player.returnRifleAmmo().ToString();
        if (playerWeapons != null)
        {
            
            index = playerWeapons.returnCurrentIndex()-1;
            
            if (index != Currentindex &&index>=0)
            {
                updateWeaponUI();
                Currentindex = index;
            }
        }
       
    }

    void updateWeaponUI()
    {
        foreach(GameObject w in weaponUI)
        {
            w.SetActive(true);
        }
        weaponUI[index].SetActive(false);
    }
}
