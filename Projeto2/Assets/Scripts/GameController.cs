using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour

// aqui ficarão as coisas de áudio também
// controla as coisas da cena do jogo

{

	public Text scoreText;
	public Text countdown;

	public float time = 30;
	private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
    	//score = 0;
    	//time = 10;
    	scoreText.text = "Score: " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
    	UpdateTime();    
    }

    void UpdateScore() 
    {
    	scoreText.text = "Score: " + score.ToString();
    }

    void UpdateTime() 
    {
    	if(time >= 0) 
    	{
            time -= Time.deltaTime;
    	    countdown.text = "Time: " + time.ToString("f0");
    		
    	}
        else
        {
            callLucio();
        }
    }

    public void AddScore(int newScoreValue) 
    {
    	score += newScoreValue;
    	UpdateScore();
    }

    void callLucio() 
    {
    	countdown.text = "Lucio";
    }
}
