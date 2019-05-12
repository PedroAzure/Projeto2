using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionEnemy : MonoBehaviour
{
	public int health = 1;
	
	public float invulnPeriod;
	float invulnTimer = 0;

	int correctLayer;

	public int scoreValue;
	private GameController gameController;

	public GameObject explosionRef;

	public Animator animator;
	public float delay = 0f;
    void Start(){
		//explosionRef = Resources.Load("Explosion");

		correctLayer = gameObject.layer;

		GameObject gameControllerObject = GameObject.FindWithTag("GameController");
		if(gameControllerObject != null) 
		{
			gameController = gameControllerObject.GetComponent<GameController>();
		}
		if(gameController == null) 
		{
			Debug.Log("Cannot find Game Object script");
		}
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
            	gameController.AddScore(scoreValue);
				die();
				//animator.SetBool("Dying", true);
        		//if(anim)
        }
    }

    void die() {
    	//GameObject explosion = (GameObject) Instantiate(explosionRef);
		
		Vector3 position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
		Instantiate(explosionRef, position, Quaternion.identity);
		Destroy (gameObject); 
    }
}
