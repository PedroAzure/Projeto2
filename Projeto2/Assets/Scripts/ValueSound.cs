using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueSound: MonoBehaviour
{
	GameObject getAudioSource;

	void Start() 
	{
		getAudioSource = GameObject.Find("MusicObject");
		GetComponent<AudioSource>().volume = getAudioSource.GetComponent<AudioSource>().volume;
	}
}
