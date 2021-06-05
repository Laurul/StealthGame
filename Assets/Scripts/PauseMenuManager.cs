using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{

    bool isPaused = false;
    [SerializeField] GameObject pauseMenuUI;
    [SerializeField] AudioSource levelMusic;
    [SerializeField] GameObject optionScreenUI;
    [SerializeField] GameObject mainScreenUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // print("TIME IS: " + Time.timeScale);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                //resume
                Resume();
            }
            else
            {

                //pause game
                Pause();
            }
        } 
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        levelMusic.Pause();
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        levelMusic.UnPause();
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
       // SceneManager.UnloadSceneAsync(1);
        SceneManager.LoadScene(0);
       
    }

    public void ShowOptionMenu()
    {
        optionScreenUI.SetActive(true);
        mainScreenUI.SetActive(false);
    }

    public void ReturnToPauseMenu()
    {
     optionScreenUI.SetActive(false);
        mainScreenUI.SetActive(true);
    }
    public bool PausedValue()
    {
        return isPaused;
    }
}
