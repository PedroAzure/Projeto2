using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShooting : MonoBehaviour
{

    // Audio's Components

    public AudioClip MusicClip;
    public AudioSource MusicSource;

    // Bullet's Components
    public GameObject bulletPrefab;
    //public Button fireButton;

    public Vector3 offset = new Vector3(0.8f, 0.1f, 0);

	public float fireDelay = 0.25f;
	float cooldownTimer = 0;
	
    Vector3 pos;
	//bool shoot = false;

    // Start is called before the first frame update
    void Start()
    {
        MusicSource.clip = MusicClip;

    	//Vector3 posPlayerShip = GameObject.Find("PlayerShip").transform.position;
        //pos = new Vector3(posPlayerShip.x, posPlayerShip.y, posPlayerShip.z);
    }

    // Update is called once per frame
    void Update()
    {
        /* for (int i = 0; i < Input.touchCount; i++)
        {
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.touches[i].position);
        }*/

        cooldownTimer -= Time.deltaTime;

       
            //if(Input.isPressed(fireButton) && cooldownTimer <= 0) {
                //Debug.Log("Pew");
                
            //}

            /*if (shoot) {
                pos.y += fireDelay;
                transform.position = pos;

            }*/
    }

    public void Fire()
    {
        

        if( cooldownTimer <= 0)
        {
            cooldownTimer = fireDelay;

            MusicSource.Play(); // play music

            Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
        }
    }
}
