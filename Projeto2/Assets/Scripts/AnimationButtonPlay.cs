using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AnimationButtonPlay : MonoBehaviour
{
    private Color tmp;

	private float incremento = 0.3f;
    private float tempo = 2f;

    private bool fadeIn = true;

    // Start is called before the first frame update
    void Start()
    {
        tmp = GetComponent<Text>().color;
		tmp.a = incremento;
        GetComponent<Text>().color = tmp;
    }

    // Update is called once per frame
    void Update()
    {
 
        if(fadeIn) 
        {
            FadeIn();
        } else 
        {
            FadeOut();
        }   
    }

    public void FadeIn() 
    {
        incremento += Time.deltaTime * 0.5f;
        tmp.a = incremento;
        GetComponent<Text>().color = tmp;

        if(incremento > 1)
     	{
     		fadeIn = false;
     	}
    }

    public void FadeOut() 
    {
   
     	incremento -= Time.deltaTime * 0.5f;
     	tmp.a = incremento;
    	GetComponent<Text>().color = tmp;

        if(incremento < 0.3f)
     	{
     		fadeIn = true;
     	}
     
    }

}
