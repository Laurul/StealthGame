﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFinish : MonoBehaviour
{
    int totalLevels = 5;
    int currentLvl;
    // Start is called before the first frame update
    void Start()
    {
        CheckCurrentLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CheckCurrentLevel()
    {
        for(int i = 0; i < totalLevels; i++)
        {
            if(SceneManager.GetActiveScene().name=="Level" + i)
            {
                currentLvl = i;
                SaveCurrentLevel();
            }
        }
    }

    void SaveCurrentLevel()
    {
        int nextLevel = currentLvl + 1;
        if (nextLevel <= totalLevels)
        {
            PlayerPrefs.SetInt("Level" + nextLevel.ToString(), 1);
        }
        LoadNextLevel();
    }

    void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}