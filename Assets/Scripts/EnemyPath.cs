using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyPath : MonoBehaviour
{
    [SerializeField] Transform[] targets;
    [SerializeField] Transform player;
     NavMeshAgent enemy;
    [SerializeField] float updateDelay;
    int index = 0;
    Transform currentTarget;
    bool changeTarget = false;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
       InvokeRepeating("Follow", 0f, updateDelay);
      
    }

    // Update is called once per frame
    void Update()
    {
        if (changeTarget == false)
        {
          

            if (HasReachedDestination())
            {
                if (index < targets.Length - 1)
                {
                    index++;
                    enemy.destination = targets[index].position;
                }
                else
                {
                    index = 0;
                    enemy.destination = targets[index].position;
                }


            }
        }
        else
        {
            enemy.destination = player.position;
          
        }
       
        

       // print(index);
       
    }

    bool HasReachedDestination()
    {
        if (Vector3.Distance(enemy.destination, enemy.transform.position) <= enemy.stoppingDistance)
        {
           
            if (!enemy.hasPath || enemy.velocity.sqrMagnitude == 0)
            {
                
                return true;
                
            }
        }
        
        return false;
    }

    void Follow()
    {
        enemy.SetDestination(targets[index].position);
    }
    public void FollowPlayer()
    {
        changeTarget = true;
    }
    public void StopFollowPlayer()
    {
        changeTarget = false;
    }
}
