using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    [SerializeField] bool isInteractable;
    [SerializeField] int index;
    // Start is called before the first frame update
    void Start()
    {
        UpdateLevelStatus();
    }

    void UpdateLevelStatus()
    {
        //if (isInteractable)
        //{
        //    GetComponent<Button>().interactable = true;
        //}
        //else
        //{
        //    GetComponent<Button>().interactable = false;
        //}

        if (PlayerPrefs.GetInt("Level"+index) > 0)
        {
            GetComponent<Button>().interactable = true;
        }
    }

    

    public void LoadSelectedLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }
}
