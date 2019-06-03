using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextScrolling : MonoBehaviour
{
    //EventsGame eventsGame;
    public AudioClip MusicClip;
    AudioSource MusicSource;
    GameObject audioSourceGameObject;

    // Start is called before the first frame update
    void Start()
    {
    
        audioSourceGameObject = GameObject.Find("MusicObject");
        MusicSource = audioSourceGameObject.GetComponent<AudioSource>();
        MusicSource.clip = MusicClip;
        MusicSource.Play();

    }

    // Update is called once per frame
    void Update()
    {
    	Vector3 pos = transform.position;

        pos.y += Time.deltaTime * 0.8f;
       
        //Atualiza posição
        transform.position = pos;

        if (pos.y > 14) 
        {
        	SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
