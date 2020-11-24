
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
    public DialougueTrigger triggerDialogue;
    [SerializeField] DialogueManager dialogueManager;
    public ScoreManager scoreManager;
    int totalEnemies;
    int currentEnenmies;
    float timer = 2.0f;
    bool seen = false;
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
            //if (Input.GetKeyDown(KeyCode.O))
            //{
            //    dialogueManager.dialogueUI.SetActive(true);

            //}
            if (dialogueManager.GetFInished())
            {
                triggerDialogue = null;

            }
            if (triggerDialogue != null)
            {
                triggerDialogue.DialogueTrigger();
               
                dialogueManager.DisplaySentanceByIndex(dialogueManager.ReturnIndex());
                if (Input.GetKeyDown(KeyCode.E))
                {

                    dialogueManager.IncreaseIndex();
                }
            }
            if (Input.GetKeyDown(KeyCode.G))
            {
                Player.ReceiveDamage(10);
            }
           
        }
       // DetectPlayer();
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    DestroyAllEnemies();
        //}
    }

    private void DetectPlayer()
    {
        if (Enemy != null)
        {
            if (alert)
            {
                Enemy.changeTarget = true;
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
                Enemy.changeTarget = false;
                Enemy.GetComponentInChildren<FadeColor>().IncreaseFade(0.01f);
            }


            if (Enemy.GetComponentInChildren<FadeColor>().GetAlphaValue() >= 1.0f)
            {
                seen = true;
                // enemy.FollowPlayer();
                Enemy.inRange = true;

                
                scoreManager.noDetection = false;
            }



            if (Enemy.GetComponentInChildren<FadeColor>().GetAlphaValue() <= 0.0f)
            {
                Enemy.inRange = false;
                
                if (seen)
                {
                    Enemy.isInvestigating = true;

                    timer -= Time.deltaTime;
                    print("timer: " + timer);
                    if (timer <= 0f)
                    {
                        Enemy.isInvestigating = false;
                        timer = 2.0f;
                        seen = false;
                    }
                }
             



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
