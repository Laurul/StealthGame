
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Player and Enemy Properties")]
    public PlayerContoller Player;
    public EnemyAI Enemy;

    [SerializeField] DetectShadow playerInShadow;
    [HideInInspector]
    public bool alert = false;
  
    public ScoreManager scoreManager;
    int totalEnemies;
    int currentEnenmies;
    float timer = 2.0f;
    bool seen = false;
  
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(this);
        totalEnemies = GameObject.FindGameObjectsWithTag("enemy").Length;
    }

    // Update is called once per frame
    void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);

    }

    private void Update()
    {
        currentEnenmies = GameObject.FindGameObjectsWithTag("enemy").Length;
        if (currentEnenmies == 0)
        {
            scoreManager.allEnemiesKilled = true;
        }



        if (Player != null)
        {
            if (Player.ReturnCurrentHealth() <= 0)
            {
                RestartMenu();
            }
        }
        
    }

    private void DetectPlayer()
    {


    }

    void DestroyAllEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        for (int i = 0; i < enemies.Length; i++)
        {
            Destroy(enemies[i]);
        }
    }

    void RestartMenu()
    {

        scoreManager.DisplayRestartScreen();


    }

    public void Restart()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
}
