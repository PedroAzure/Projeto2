using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    
    public GameObject powerPrefab;

    public GameController controller;

    public float powerRate = 5;
    float nextPower;
    public int nextPowerType = 1;

    public int maxPowerlTypes = 1;

    public float numberOfPower = 0;

    public int quantidadePower = 0;

    // Start is called before the first frame update
    void Start()
    {
        PlayerCollision.ElenaGetPowerUpSubscriber += AddPower;

        nextPower = powerRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.spawner.Equals("SPAWNING"))
            {

            nextPower -= Time.deltaTime;

            if(nextPower <= 0 && quantidadePower < 3) 
            {
                
                nextPower = powerRate;

                Vector3 position = new Vector3(11, Random.Range(-4.4f, 4.3f), 0);

                Instantiate(powerPrefab, position, Quaternion.identity);

            } 
        }
    }

    void AddPower ()
    {
    
        if (quantidadePower < 3)  
        {
            quantidadePower++;

            Debug.Log(quantidadePower);
        }

    }

    void OnDisable() 
    {
        PlayerCollision.ElenaGetPowerUpSubscriber -= AddPower;

        // caso o objeto não exista mais no jogo, a inscrição dele no evento será retirada;
    }
}
