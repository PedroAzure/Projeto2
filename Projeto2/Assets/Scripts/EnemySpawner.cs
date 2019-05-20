using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyPrefab;

    public float enemyRate = 5;
    float nextEnemy;

    bool spawning = false;

    void Start()
    {
        GameController.onEnemyDead += Kill;
        GameController.onEnemyHit += Hit;
        
        nextEnemy = enemyRate;
    }

    // Update is called once per frame
    void Update()
    {
        if(spawning)
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

    void Kill() 
    {

        Debug.Log("Eu imimigo morri");       
        
        Destroy(gameObject);

    }

    void Hit() 
    {

        Debug.Log("Eu imimigo fui acertado");       
        // pode fazer aqui o decremento do life do inimigo

    }

    void OnDisable() 
    {
        GameController.onEnemyDead -= Kill; 
        GameController.onEnemyHit -= Hit; 
        // caso o objeto não exista mais no jogo, a inscrição dele no evento será retirada;
    }

    public void setSpawner(bool check)
    {
        this.spawning = check;
    }
}
