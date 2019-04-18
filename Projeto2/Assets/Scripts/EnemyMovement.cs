﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        pos.y -= maxSpeed;
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