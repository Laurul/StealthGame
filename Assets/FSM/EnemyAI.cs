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
    public HitScanGun gun;
    [HideInInspector] public Transform currentTarget;
    [HideInInspector] public bool changeTarget = false;
    [HideInInspector] public bool inRange = false;
    [HideInInspector] public NavMeshAgent navAgent;
    [HideInInspector] public bool isIdle = false;
    [HideInInspector] public bool isInvestigating = false;

    [HideInInspector] public int index = 0;
    [HideInInspector] public Animator enemyAnimator;
    

    private void OnEnable()
    {
        enemyAnimator = GetComponent<Animator>();
        navAgent = GetComponent<NavMeshAgent>();
        currentState = patrol;
        allPaths =new int[] { 0,1,2,3,4,5,6,3,2,4,5,6,0,1,2,3,6};

    }

    // Update is called once per frame
    void Update()
    {
        currentState = currentState.ActivateState(this);
        nameOfCurrentState = currentState.ToString();
        print(nameOfCurrentState);
    }
}
