using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WomanMoviment : MonoBehaviour
{
    public float speed;
    Vector2 min;

    GameObject controller;
    public Girls girls; 

    void Start()
    {
        controller = GameObject.FindWithTag("GameController");
        girls = controller.GetComponent<Girls>(); 

        PlayerCollision.ElenaGetWomanSubscriber += KillWoman;
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
            //girls.numberOfEnemies--;
            Destroy(gameObject);
        }
    }

    void KillWoman() 
    {
        Destroy(gameObject);
    }

    void OnDisable() 
    {
        PlayerCollision.ElenaGetWomanSubscriber -= KillWoman;

        // caso o objeto não exista mais no jogo, a inscrição dele no evento será retirada;
    }
}
