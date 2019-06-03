using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
   
    public AudioClip MusicClip;
    private AudioSource MusicSource;

    GameObject audioSourceGameObject;

        // Obtém o componente AudioSource do objeto.

    // Start is called before the first frame update
    void Start()
    {
        audioSourceGameObject = GameObject.Find("MusicObject");
        MusicSource = audioSourceGameObject.GetComponent<AudioSource>();
        MusicSource.clip = MusicClip;
        MusicSource.Play();
        DontDestroyOnLoad(audioSourceGameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
