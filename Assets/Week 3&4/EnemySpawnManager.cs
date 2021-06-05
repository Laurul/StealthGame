using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField] List<Transform> spawnPoints;
    [SerializeField] GameObject enemy;


    private void Awake()
    {
        foreach (Transform s in spawnPoints)
        {
            ReplaceEnemy(s);
        }
    }
    void Start()
    {
        StartCoroutine(EnemyRespawn());
    }

    void ReplaceEnemy(Transform t)
    {

        Instantiate(enemy, t.position, Quaternion.identity, t);
    }


    IEnumerator EnemyRespawn()
    {
        while (true)
        {
            yield return null;
            for (int i = 0; i < spawnPoints.Count; i++)
            {

                if (spawnPoints[i].childCount == 0)
                {

                    yield return new WaitForSeconds(4f);
                    ReplaceEnemy(spawnPoints[i]);


                }
            }
        }
    }
}
