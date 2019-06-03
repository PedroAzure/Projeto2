﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{
	public int health = 1;
	
	public float invulnPeriod;
	float invulnTimer = 0;

	int correctLayer;

	public int scoreValue;
	private GameController gameController;

    public Material matWhite;
    private Material matDefault;
    SpriteRenderer sr;

    public Slider sliderHP;

	public GameObject explosionRef;

    public GameObject gameOverMenuUI;
    public Animator gameOverAnimator;

    void Start(){
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
    }

    void Update()
    {
    	invulnTimer -= Time.deltaTime;

    	if(invulnTimer <= 0)
    	{
    		gameObject.layer = correctLayer;
            Invoke("ResetMaterial", 0);
        }

    	if(health <= 0)
        {
            gameController.AddScore(scoreValue);
            die();
        }

        sliderHP.value = health;
    }

    void die() {
        //Time.timeScale = 0f;
        gameOverAnimator.SetTrigger("Over");
        gameOverAnimator.SetBool("PauseCheck", true);
        Vector3 position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
		Instantiate(explosionRef, position, Quaternion.identity);
    	Destroy(gameObject);
    }

    void ResetMaterial()
    {
        sr.material = matDefault;
    }


}
