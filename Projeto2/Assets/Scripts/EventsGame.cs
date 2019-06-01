using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventsGame : MonoBehaviour
    // aqui estão os eventos que são comuns a todos no jogo

{
    float m_MySliderValue; 
    public AudioSource MusicSource;

    // Start is called before the first frame update
    void Start()
    {
        //GameController.changingVolumeSound += changeVolume;
        m_MySliderValue = MusicSource.volume;
        GetComponent<Slider>().value = MusicSource.volume * 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDisable() 
    {
    	//GameController.onLucioIsComing -= changeVolume; 
    	// caso o objeto não exista mais no jogo, a inscrição dele no evento será retirada;
    }

    public float GetVolume() 
    {
        return m_MySliderValue;
    }

    public void ChangeVolume() 
    {     
        m_MySliderValue = GetComponent<Slider>().value;
        MusicSource.volume = m_MySliderValue * 0.01f;
       
        Debug.Log(m_MySliderValue);

        //ScriptStatic.Volume = MusicSource.volume;

    	/*
        if (changingVolumeSound != null) 
            {
                changingVolumeSound();
            }
        */
    }

}