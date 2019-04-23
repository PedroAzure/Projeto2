using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
	public int health = 1;
	
	public float invulnPeriod;
	float invulnTimer = 0;

	int correctLayer;
	
    void Start(){
		correctLayer = gameObject.layer;
	}

    // Update is called once per frame
    void OnTriggerEnter2D()
    {
        Debug.Log("Trigger");

        health--;
        invulnTimer = invulnPeriod;
        gameObject.layer = 10;
    }

    void Update()
    {
    	invulnTimer -= Time.deltaTime;

    	if(invulnTimer <= 0)
    	{
    		gameObject.layer = correctLayer;
    	}

    	if(health <= 0)
        {
        	die();
        }
    }

    void die() {
    	Destroy(gameObject);
    }
}
