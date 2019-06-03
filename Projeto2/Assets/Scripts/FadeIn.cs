using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeIn : MonoBehaviour
{

	private Color tmp;

	private float incremento = 0;
    private float tempo = 2f;
    private float timeNewScene = 2.5f;

    public LevelChanger changer;


    // Start is called before the first frame update
    void Start()
    {
        tmp = GetComponent<SpriteRenderer>().color;
		tmp.a = incremento;
        GetComponent<SpriteRenderer>().color = tmp;
    }

    // Update is called once per frame
    void Update()
    {
 
 		if (tempo >= 0) 
        {
            tempo -= Time.deltaTime;
        } else 
        {
            if(incremento < 1)
     		{
     			Fade();
     		} else 
            {
                ChangeScene();
            }   
        }
    }

    public void Fade() 
    {
        incremento += Time.deltaTime * 0.3f;
        tmp.a = incremento;
        GetComponent<SpriteRenderer>().color = tmp;
    }

    public void ChangeScene() 
    {
        if(timeNewScene >= 0) 
        {
            timeNewScene -= Time.deltaTime;
        } else 
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            changer.FadeToNextLevel();
        }
    }

}
