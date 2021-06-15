using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
   // public string PlayerName;
    //public int PLayerXP = 0;
    //public int PLayerLEvel = 1;
    //public int PlayerHP = 50;
    [SerializeField] PlayerContoller playerReference;
    [SerializeField] ScoreManager scoreReference;
    [SerializeField] ActiveAbilitySwapper swapperReference;
    [SerializeField] GameObject specialAttack1;
  
    public List<PlayerAttributes> Attributes = new List<PlayerAttributes>();
    public List<Skills> PlayerSkills = new List<Skills>();

    bool canRegenerateHealth = false;
    bool takeLessDamage = false;
    bool harderDetection = false;
    bool confusion = false;

    public void AllowRegen()
    {
        canRegenerateHealth = true;
    }

    [HideInInspector] public int health = 100;
    [HideInInspector] public int energy = 100;
    [HideInInspector] public int maxHealth = 100;
    [HideInInspector] public int maxEnergy = 100;



    private float energyCountDown = 1f;
    private float healthCountDown = 5f;
    private float slowCountDown = 10f;


    bool ok = false;
    bool once = false;
    [SerializeField]
    private int m_PlayerXP = 0;
    public int PLayerXP
    {
        get { return m_PlayerXP; }
        set
        {
            m_PlayerXP = value;
            if (onXPChange != null)
            {
                onXPChange();
            }
        }
    }


    [SerializeField]
    private int m_playerLevel = 1;
    public int PlayerLEvel
    {
        get { return m_playerLevel; }
        set
        {
            m_playerLevel = value;
            if (onLevelChange != null)
            {
                onLevelChange();
            }
        }
    }
    public delegate void OnXPChange();
    public event OnXPChange onXPChange;

    public delegate void OnLevelChange();
    public event OnLevelChange onLevelChange;

    public void UpdateLevel(int amount)
    {
        PlayerLEvel += amount;
    }
    public void UpdateXP(int amount)
    {
        PLayerXP += amount;
    }

    
    private void Start()
    {
        playerReference.maxHealth = maxHealth;
        //playerReference.currentHealth = health;
        playerReference.maxEnergy = maxEnergy;
        //playerReference.currentEnergy = energy;

       
    }
    private void Update()
    {
        if (scoreReference.once&& once==false)
        {
            once = true;
            UpdateXP(scoreReference.totalScore / 10);
            
        }

        if (canRegenerateHealth)
        {
            healthCountDown -= Time.deltaTime;
            if (healthCountDown <= 0 && playerReference.currentHealth < playerReference.maxHealth)
            {
                healthCountDown = 5f;
                playerReference.currentHealth += 10f;
                // health += 1;
            }
        }


        //energyCountDown -= Time.deltaTime;     
        //if (energyCountDown <= 0 && energy < maxEnergy)
        //{
        //    energy += 1;
        //    energyCountDown = 1f;
        //}

        if (harderDetection)
        {
            LessDetection();
        }

        if (confusion && ok)
        {
            slowCountDown -= Time.deltaTime;
            if (slowCountDown > 0f)
            {
                print("YOU CANT SLOW AN ENEMY FOR ANOTHER " + Mathf.FloorToInt(slowCountDown) + " seconds");
            }
            else
            {
                ok = false;
                slowCountDown = 10f;
                print("YOU CAN NOW SLOW AN ENEMY");

            }

        }
    }


    private void IncreaseMaxHealth()
    {
        playerReference.maxHealth += 15;

       // maxHealth += 15;
        //health = maxHealth;
    }
   
    private void IncreaseMaxEnergy()
    {
        playerReference.maxEnergy += 30;
       // maxEnergy += 30;
        //energy = maxEnergy;
    }

    public void IncreaseDefense()
    {
        playerReference.defense += 1;
        //if (takeLessDamage)
        //{
        //    health -= 5;
        //}
        //else
        //{
        //    health -= 10;
        //}
    }

    public void TakeEnergy()
    {
        energy -= 10;
    }

    private void LessDetection()
    {
        print("WOW, YOU ARE ALMOST INVISIBLE!");
    }

    public void SlowEnemy()
    {
        ok = true;

    }
    public void AddNewAttack()
    {
        swapperReference.AddToList(specialAttack1);
    }

    public void ActivateSkill(int index)
    {

        switch (index)
        {
            case 0:
                print("NO SKILL IS ACTIVE");
                break;
            case 1:
                 IncreaseMaxEnergy();
                //AddNewAttack();
                break;
            case 2:
                IncreaseMaxHealth();
                break;
            case 3:
                canRegenerateHealth = true;
                break;
            case 4:
                IncreaseDefense();
                break;
            case 5:
                harderDetection = true;
                break;
            case 6:
                confusion = true;
                break;
        }
    }
    public void ResetSkills()
    {
        foreach(PlayerAttributes attrbute in Attributes)
        {
            attrbute.amount = 1;
        }

        PlayerSkills.Clear();
        m_PlayerXP = 0;
        m_playerLevel = 1;
    }

}
