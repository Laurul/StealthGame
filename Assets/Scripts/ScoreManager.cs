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
    int killingSpree = 0;

    float scoreTimer = 6f;
    float timer;
    bool once = false;
    int totalScore=0;
    // Start is called before the first frame update
    void Start()
    {
        timer = scoreTimer;
    }

    // Update is called once per frame
    void Update()
    {
        print("the score is: "+score);

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
       
      //  scoreBrackets[2].text =;
       
        
        

       

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

        if (allEnemiesKilled && once == false)
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
        }
    }
}
