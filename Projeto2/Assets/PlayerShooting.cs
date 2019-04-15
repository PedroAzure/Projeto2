using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

	public float fireDelay;
	float cooldownTimer = 0;
	Vector3 pos;
	bool shoot = false;

    // Start is called before the first frame update
    void Start()
    {
    	Vector3 posPlayerShip = GameObject.Find("PlayerShip").transform.position;
        pos = new Vector3(posPlayerShip.x, posPlayerShip.y, posPlayerShip.z);
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer -= Time.deltaTime;

        if(Input.GetKeyDown("space") && cooldownTimer <= 0) {
        	Debug.Log("Pew");

        	fireDelay = 0.25f;

        	cooldownTimer = fireDelay;
        }

        if (shoot) {
        	pos.y += fireDelay;
        	transform.position = pos;

        }
    }
}
