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
    public GameObject explosionHit;

    public Animator animator;
	public float delay = 0f;

    SpriteRenderer sr;
    public Material matWhite;
    private Material matDefault;

    void Start()
    {
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

        sr = GetComponent<SpriteRenderer>();

        matDefault = sr.material;   
    }	

    // Update is called once per frame
    void OnTriggerEnter2D()
    {
        Debug.Log("Trigger");

        health--;
        invulnTimer = invulnPeriod;
        sr.material = matWhite;
        gameObject.layer = 10;

        if (health <= 0)
        {
            gameController.AddScore(scoreValue);
            die();
        }

        else
        {
            Vector3 position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Instantiate(explosionHit, position, Quaternion.identity);
            Invoke("ResetMaterial", .1f);
        }
    }

    void Update()
    {
    	invulnTimer -= Time.deltaTime;

    	if(invulnTimer <= 0)
    	{
    		gameObject.layer = correctLayer;
    	}
    }

    void die() {
    	//GameObject explosion = (GameObject) Instantiate(explosionRef);
		
		Vector3 position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
		Instantiate(explosionRef, position, Quaternion.identity);
		Destroy (gameObject); 
    }

    void ResetMaterial()
    {
        sr.material = matDefault;
    }
}
