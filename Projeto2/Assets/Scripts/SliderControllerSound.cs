using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderControllerSound : MonoBehaviour
{
    public delegate void GetVolume(float volume); // observer
    public static event GetVolume getVolume;

    float m_MySliderValue = 50f; 
 
    public Text textValueSound;

    public AudioSource myAudioSource;

    GameObject cenarioAudio;

    // Start is called before the first frame update
    void Start()
    {
        cenarioAudio = GameObject.Find("Cenario");

        GetComponent<Slider>().value = m_MySliderValue;
        textValueSound.text = m_MySliderValue.ToString();       
    }

    public void ChangeVolume() 
    {     
        m_MySliderValue = GetComponent<Slider>().value;
        textValueSound.text = m_MySliderValue.ToString();

        cenarioAudio.GetComponent<AudioSource>().volume = GetComponent<Slider>().value * 0.01f;
        myAudioSource.volume = GetComponent<Slider>().value * 0.01f;


        if (getVolume != null) 
        {
            getVolume(myAudioSource.volume);
        }
    }
}
