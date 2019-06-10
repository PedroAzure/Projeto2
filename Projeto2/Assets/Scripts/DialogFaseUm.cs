using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogFaseUm : MonoBehaviour
{
    public AudioSource MyAudioSource;
	public AudioClip MyAudioClip;

	void Start() 
	{
		MyAudioSource.clip = MyAudioClip;
	}

    public void PlaySound() 
    {
        MyAudioSource.Play();
    }
}
