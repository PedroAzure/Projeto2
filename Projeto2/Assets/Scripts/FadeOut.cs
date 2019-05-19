using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{

	private Color tmp;

	private float decremento = 1f;
    private float tempo = 3f;

    // Start is called before the first frame update
    void Start()
    {
        tmp = GetComponent<SpriteRenderer>().color;
		
    }

    // Update is called once per frame
    void Update()
    {
 
        if (tempo >= 0) 
        {
            tempo -= Time.deltaTime;
        } else 
        {
     		if(decremento > 0)
     		{
     			decremento -= Time.deltaTime * 0.3f;
     			tmp.a = decremento;
    			GetComponent<SpriteRenderer>().color = tmp;
     		}
        }

    }

    public void Fade (bool ok) 
    {

    }

}
