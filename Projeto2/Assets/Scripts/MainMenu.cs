using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

	public AudioClip MusicClip;
	public AudioSource MusicSource;

    EventsGame eventsGame;

    void Start () 
	{
        
        //eventsGame = new EventsGame();
        //MusicSource.volume = eventsGame.GetVolume();
		MusicSource.clip = MusicClip;
     
    }

    public void PlayGame(){

    	MusicSource.Play(); // play music

    }

    public void QuitGame(){

        Debug.Log("Quit");
        //Application.Quit();
    }
}
