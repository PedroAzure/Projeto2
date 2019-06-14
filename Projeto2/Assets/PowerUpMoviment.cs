using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpMoviment : MonoBehaviour
{

    public float speed;
    Vector2 min;

    GameObject controller;
    public PowerUp power;


    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.FindWithTag("GameController");
        power = controller.GetComponent<PowerUp>(); 

        PlayerCollision.ElenaGetPowerUpSubscriber += KillPowerUp;   
    }

    void Update()
    {
        Moviment();
    }

    void Moviment() 
    {
        Vector3 position = transform.position;

        position = new Vector3(position.x - speed * Time.deltaTime, position.y, -2f);

        transform.position = position;

        min = Camera.main.ViewportToWorldPoint (new Vector2(0,0));

        if(transform.position.x < min.x - 2){
            power.numberOfPower--;
            Destroy(gameObject);
        }
    }

    void KillPowerUp() 
    {
        Destroy(gameObject);
    }

    void OnDisable() 
    {
        PlayerCollision.ElenaGetPowerUpSubscriber -= KillPowerUp;

        // caso o objeto não exista mais no jogo, a inscrição dele no evento será retirada;
    }
}
