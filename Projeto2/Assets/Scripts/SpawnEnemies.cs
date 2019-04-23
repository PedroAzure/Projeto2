using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyPrefab;

    public float enemyRate = 5;
    float nextEnemy;

    void Start()
    {
        nextEnemy = enemyRate;
    }

    // Update is called once per frame
    void Update()
    {
        nextEnemy -= Time.deltaTime;

        if(nextEnemy <= 0) 
        {
            nextEnemy = enemyRate;

            Vector3 position = new Vector3(11, Random.Range(-4.4f, 4.3f), 0);
          
            Instantiate(enemyPrefab, position, Quaternion.identity);
        }        
    }
}
