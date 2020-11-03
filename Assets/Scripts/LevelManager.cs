using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject content;
    Button[] levelButtons;

    private void Awake()
    {
        int levelUnlocked = PlayerPrefs.GetInt("LevelUnlocked", 1);
        if (PlayerPrefs.GetInt("Level") >1){
            levelUnlocked = PlayerPrefs.GetInt("Level");
        }

        levelButtons = new Button[content.transform.childCount];
        
        for(int i = 0; i < levelButtons.Length; i++)
        {
            levelButtons[i] = content.transform.GetChild(i).GetComponent<Button>();
            if (i + 1 > levelUnlocked)
            {
                levelButtons[i].interactable = false;
            }
        }
    }

    public void LoadScene(int nextLevel)
    {
        PlayerPrefs.SetInt("Level", nextLevel);
        SceneManager.LoadScene(nextLevel);
    }
}
