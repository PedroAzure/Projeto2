using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public class EnemyMovement : MonoBehaviour
{
    public float maxSpeed;
    Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
  		pos = new Vector3(Random.Range(-6f, 6f), Random.Range(7f, 4.5f), 10);
  		transform.position = pos;
    }

    // Update is called once per frame
    void Update()
    {  
        pos.x -= 1f * maxSpeed * Time;
        //pos.x += Input.GetAxis("Horizontal") * maxSpeed * Time.deltaTime; 

        transform.position = pos;

        if (pos.y < -4) {
        	Destroy(gameObject);
            Debug.Log("Die");
        }
    }

    void OnCollisionEnter2D() {
        Debug.Log("Collision");
    }

    void OnTriggerEnter2D() {
        Debug.Log("Trigger");
    }
}
*/

public class Enemy2Movement : MonoBehaviour
{
    public float speed;
    Vector2 min;

    public GameObject controller;
    public SpawnEnemies spawner;

    void Start()
    {
        controller = GameObject.FindWithTag("GameController");
        spawner = controller.GetComponent<SpawnEnemies>();
    }

    void Update()
    {
        Moviment();
    }

    void Moviment()
    {
        Vector3 position = transform.position;

        position = new Vector3(position.x, position.y - speed * Time.deltaTime, -2f);

        transform.position = position;

        min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        if (transform.position.x < min.x - 2)
        {
            spawner.numberOfEnemies--;
            Destroy(gameObject);
        }
    }

}