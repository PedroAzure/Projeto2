using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{

    GameObject audioSourceGameObject;

    // Start is called before the first frame update
    void Start()
    {
        audioSourceGameObject = GameObject.Find("MusicObject");
        GetComponent<AudioSource>().volume = audioSourceGameObject.GetComponent<AudioSource>().volume;
 
        //DontDestroyOnLoad(audioSourceGameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
