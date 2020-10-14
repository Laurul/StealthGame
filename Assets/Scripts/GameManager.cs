﻿
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
    public FovCOne EnemyFov;
    [SerializeField] DetectShadow playerInShadow;
    [HideInInspector]
   public bool alert = false;
    [SerializeField] DialougueTrigger triggerDialogue;
    [SerializeField] DialogueManager dialogueManager;
    [SerializeField] ScoreManager scoreManager;
    int totalEnemies;
    int currentEnenmies;
    //[Header("UI Properties")]
    //UI health orb, UI energy, score board points, multypliers etc;
    // int score=0;

    // Start is called before the first frame update
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
        ///ON ENEMY DEATH CALL MULTYPLAYER METHOD IN SCORE MANAGER
        //int dif = totalEnemies - currentEnenmies;
        //if (dif >= 0 && dif <= totalEnemies - 1)
        //{
        //    //call killing spree multiplier award from score manager
        //}

        if (Player != null)
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                dialogueManager.dialogueUI.SetActive(true);
               
            }

            if (dialogueManager.dialogueUI.activeSelf)
            {
                triggerDialogue.DialogueTrigger();
                dialogueManager.DisplaySentanceByIndex(dialogueManager.ReturnIndex());
                if (Input.GetKeyDown(KeyCode.H))
                {

                    dialogueManager.IncreaseIndex();
                }
            }
            if (Input.GetKeyDown(KeyCode.G))
            {
                Player.ReceiveDamage(10);
            }
           
        }
        DetectPlayer();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DestroyAllEnemies();
        }
    }

    private void DetectPlayer()
    {
        if (Enemy != null)
        {
            if (alert)
            {
                if (playerInShadow.ReturnCover())
                {
                    Enemy.GetComponentInChildren<FadeColor>().IncreaseOpacity(0.01f);
                }
                else
                {
                    Enemy.GetComponentInChildren<FadeColor>().IncreaseOpacity(0.004f);
                }

            }

            if (alert == false)
            {

                Enemy.GetComponentInChildren<FadeColor>().IncreaseFade(0.01f);
            }


            if (Enemy.GetComponentInChildren<FadeColor>().GetAlphaValue() >= 1.0f)
            {
                // enemy.FollowPlayer();
                Enemy.changeTarget = true;
                scoreManager.noDetection = false;
            }



            if (Enemy.GetComponentInChildren<FadeColor>().GetAlphaValue() <= 0.0f)
            {
                Enemy.changeTarget = false;
                // new WaitForSeconds(0.2f);
                //enemy.StopFollowPlayer();
            }
            //if(targets.Count>0)
            //foreach(Transform target in targets)
            //{
            //    print(target.gameObject.name);
            //}
        }

    }

    void DestroyAllEnemies()
    {
       GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        for(int i = 0; i < enemies.Length; i++)
        {
            Destroy(enemies[i]);
        }
    }
}
