using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    int score=0;
    [HideInInspector] public bool noDetection = true;
    [HideInInspector] public bool allEnemiesKilled = false;
    [SerializeField] Text[] scoreBrackets;
    [SerializeField] GameObject scoreScreen;
    bool finishedFast =true;
    [Tooltip("Amount of time that the player can spend in the level and still recieve the finished level fast bonus")]
    [SerializeField] float fastLevelTimer = 180f;
    

    float scoreTimer = 6f;
    float timer;
   [HideInInspector] public bool once = false;
    int totalScore=0;

    GameObject[] allEnemies;
    int killingSpreeIndex = 0;
    int killingSpreeScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        timer = scoreTimer;
        allEnemies= GameObject.FindGameObjectsWithTag("enemy");
        killingSpreeIndex = allEnemies.Length;
    }

    // Update is called once per frame
    void Update()
    {
        print("the score is: "+score);
        allEnemies = GameObject.FindGameObjectsWithTag("enemy");

        if (once == false)
        {
            if (timer >= 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
               
                score += 15;
                totalScore += score;
                timer = scoreTimer;
            }

            if (fastLevelTimer >= 0)
            {
                fastLevelTimer -= Time.deltaTime;
            }
            else
            {
                finishedFast = false;
            }
        }

        scoreBrackets[0].text = score.ToString();

      


        if (allEnemies.Length < killingSpreeIndex)
        {
            killingSpreeScore += 100;
            killingSpreeIndex = allEnemies.Length;
        }

        if (allEnemies.Length == 0)
        {
            allEnemiesKilled = true;
        }

        scoreBrackets[2].text =killingSpreeScore.ToString();

        if (noDetection)
        {
            noDetection = false;
            int bonusDetect = 800;
            scoreBrackets[1].text = bonusDetect.ToString();
            totalScore += bonusDetect;
        }


        if (finishedFast)
        {
            finishedFast = false;
            int timeBonus = 100;
            scoreBrackets[3].text = timeBonus.ToString();
            totalScore += timeBonus;
        }

        if (allEnemiesKilled&&once==false)
        {
            once = true;
            int eliminatedAll = 300;
            scoreBrackets[4].text =eliminatedAll.ToString();
            totalScore += eliminatedAll;
            
                
            
        }
        scoreBrackets[5].text = totalScore.ToString() ;

        if (once)
        {

            scoreScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
