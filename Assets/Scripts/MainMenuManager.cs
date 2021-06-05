using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject optionsMenu;
    [SerializeField] GameObject levels;
    
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GoToOptionsMenu()
    {
        optionsMenu.SetActive(true);
        mainMenu.SetActive(false);
        levels.SetActive(false);
    }

    public void GoToMainMenu()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
        levels.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void DisplayLevels()
    {
        levels.SetActive(true);
        mainMenu.SetActive(false);
    }

}
