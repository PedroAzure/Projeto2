using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetVolume : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        SliderControllerSound.getVolume += AlterarVolume;
    }

    // Update is called once per frame
    void Update()
    {
   
    }

    public void AlterarVolume(float volume) 
    {
        GetComponent<AudioSource>().volume = volume;

    }
}
