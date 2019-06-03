using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptStatic: MonoBehaviour
{
    //public AudioSource MusicSourceGetVolume;

    GameObject audioSourceGameObj;

    void Start()
    {
        audioSourceGameObj = GameObject.Find("MusicObject");
    }

    void Update() 
    {
        GetComponent<AudioSource>().volume = audioSourceGameObj.GetComponent<AudioSource>().volume;
        Debug.Log(GetComponent<AudioSource>().volume);
    }

}
