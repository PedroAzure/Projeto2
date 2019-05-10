using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{

    // Audio's Components

    public AudioClip MusicClip;
    public AudioSource MusicSource;

	// inicio das variáveis da bala
    public GameObject bullet;
    public Vector3 offset = new Vector3(0.8f, 0.1f, 0);
    public float fireDelay = 1.5f;
    float cooldownTimer = 0;
    Vector3 pos;
    // fim das variáveis da bala

    Vector2 min;

    // Start is called before the first frame update
    void Start()
    {
        MusicSource.clip = MusicClip;
    }

    // Update is called once per frame
    void Update()
    {
        Shooting();
    }

    void Shooting() 
    {
        cooldownTimer -= Time.deltaTime;

        if(cooldownTimer <= 0) {
            Debug.Log("Pew Inimigo");

            MusicSource.Play(); // play music


            cooldownTimer = fireDelay;

            Instantiate(bullet, transform.position - offset, transform.rotation);

            min = Camera.main.ViewportToWorldPoint (new Vector2(0,0));
            
            if(transform.position.x < min.x - 2){
                Destroy(bullet);
            }
        }
    }
}
