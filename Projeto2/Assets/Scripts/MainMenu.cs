using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

	public AudioClip MusicClip;
	public AudioSource MusicSource;

	void Start () 
	{
		MusicSource.clip = MusicClip;
	}

    public void PlayGame(){
    	MusicSource.Play(); // play music

    	// chance scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //SceneManager.LoadScene("Dialog");
    }

    public void QuitGame(){

        Debug.Log("Quit");
        //Application.Quit();
    }
}
