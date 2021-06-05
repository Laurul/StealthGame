using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeapons : MonoBehaviour
{
    [SerializeField] List< GameObject> WeaponPrefabs;
    int currentIndex = 0;
   
    // Start is called before the first frame update
    void Start()
    {
        checkAlreadyActive();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentIndex = 1;
            WeaponPrefabs[0].SetActive(true);
            WeaponPrefabs[1].SetActive(false);
            WeaponPrefabs[2].SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentIndex = 2;
            WeaponPrefabs[1].SetActive(true);
            WeaponPrefabs[2].SetActive(false);
            WeaponPrefabs[0].SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentIndex = 3;
            WeaponPrefabs[2].SetActive(true);
            WeaponPrefabs[1].SetActive(false);
            WeaponPrefabs[0].SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            NextWeapon(currentIndex);
        }
       
    }

    public void NextWeapon(int index)
    {
        index %= WeaponPrefabs.Count;
        currentIndex = index+1;
        foreach (GameObject weapon in WeaponPrefabs)
        {
            weapon.SetActive(false);
        }
        WeaponPrefabs[index].SetActive(true);
    }
    void checkAlreadyActive()
    {
        foreach(GameObject g in WeaponPrefabs)
        {
            if (g.activeSelf)
            {
                currentIndex = WeaponPrefabs.IndexOf(g) + 1;
            }
        }
    }

    public int returnCurrentIndex()
    {
        return currentIndex;
    }
}
