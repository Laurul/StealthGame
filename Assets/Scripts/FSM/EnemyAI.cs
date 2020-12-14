using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAI : MonoBehaviour
{


    public int[] allPaths;



    [SerializeField]
    private string nameOfCurrentState;
    private IState currentState;

    float updateDelay;



    public Transform[] targets;
    public Transform player;
    public float attentionTimer = 3.0f;

    [HideInInspector]
    public IdleState idle = new IdleState();
    public PatrolState patrol = new PatrolState();
    public ChaseState chase = new ChaseState();
    public AttackState attack = new AttackState();
    public InvestigateState investigate = new InvestigateState();
    [HideInInspector] public Transform currentTarget;
    [HideInInspector] public bool changeTarget = false;
    [HideInInspector] public bool inRange = false;
    [HideInInspector] public NavMeshAgent navAgent;

    [HideInInspector] public bool isInvestigating = false;

    [HideInInspector] public int index = 0;
    [HideInInspector] public Animator enemyAnimator;

    public HitScanGun gun;
    public bool UseRandomAnimation;

    AnimatorOverrideController aoc;

    [HideInInspector] public bool isIdle = false;
    [SerializeField] float idleTime; //THe time frame (in seconds) in which an enemy can become idle for a number of times
    [SerializeField] float idlePeriod; //how much time an enemy can stay idle
    [SerializeField] float numberOfIdlesAllowed; // how many times an enemy can be idle in the given timeframe

    float auxIdleTime;
    float auxIdlePeriod;
    float auxNumberofIdles;
    bool repeat = true;
    public RandomAnimation randomAnim;

    List<int> idlePos;
    private void Start()
    {
       
        auxIdleTime = idleTime;
        auxIdlePeriod = idlePeriod;
        auxNumberofIdles = numberOfIdlesAllowed;

       
    }
    private void OnEnable()
    {


        idlePos = new List<int>();
        enemyAnimator = GetComponent<Animator>();
        navAgent = GetComponent<NavMeshAgent>();
        currentState = patrol;
        //allPaths = new int[] { 0, 1, 2, 3, 4, 5 };//, 6, 3, 2, 4, 5, 6, 0, 1, 2, 3, 6 };

        AddNewSettOfIdlePos();
        if (UseRandomAnimation)
        {
            aoc = new AnimatorOverrideController(enemyAnimator.runtimeAnimatorController);
            enemyAnimator.runtimeAnimatorController = aoc;
        }

    }

    // Update is called once per frame
    void Update()
    {
        currentState = currentState.ActivateState(this);
        nameOfCurrentState = currentState.ToString();

        if (idlePos.Count == 0)
        {
            AddNewSettOfIdlePos();
        }
        // print(nameOfCurrentState);

        for (int i = 0; i < idlePos.Count; i++)
        {
            // print("index " + (i + 1) + " occupies possition " + idlePos[i]);
            if (index == idlePos[i])
            {
                isIdle = true;
                idlePos.Remove(idlePos[i]);
            }
        }

        //foreach (int positionIndex in idlePos)
        //{
        //    if (index == positionIndex)
        //    {
        //        isIdle = true;
        //        idlePos.Remove(positionIndex);
        //    }
        
        //}


        if (isIdle)
        {
            auxIdlePeriod -= Time.deltaTime;
            if (auxIdlePeriod <= 0)
            {
                isIdle = false;
                auxIdlePeriod = idlePeriod;

            }
        }
  

    }
     void AddNewSettOfIdlePos()
    {
        while (idlePos.Count < numberOfIdlesAllowed)
        {
            int r = Random.Range(0, allPaths.Length);
            idlePos.Add(r);
        }
    }
}
