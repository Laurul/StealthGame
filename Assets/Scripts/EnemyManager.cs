using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    EnemyAI Enemy;
    [HideInInspector]
    public bool alert = false;
    float timer = 2.0f;
    bool seen = false;
    SoundDetection enemySoundDetection;
  
    // Start is called before the first frame update
    private void Awake()
    {
        
    }

    void Start()
    {
        Enemy = GetComponent<EnemyAI>();
        enemySoundDetection = GetComponent<SoundDetection>();
    }

    // Update is called once per frame
    void Update()
    {
        DetectPlayer();
    }


    private void DetectPlayer()
    {
        if (Enemy != null)
        {
            if (alert)
            {
                Enemy.changeTarget = true;
                if (enemySoundDetection.GetAlertstatus()==true)
                {
                    Enemy.GetComponentInChildren<FadeColor>().IncreaseOpacity(0.05f);
                }
                else
                {
                    Enemy.GetComponentInChildren<FadeColor>().IncreaseOpacity(0.01f);
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


                GameManager.Instance.scoreManager.noDetection = false;
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
        else
        {
            print("NO ENEMY ATTACHED TO THIS OBJECT!!!");
        }

    }
}
