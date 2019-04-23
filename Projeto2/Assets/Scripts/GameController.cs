using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour


// aqui ficarão as coisas de áudio também
// controla as coisas da cena do jogo

{

	//public GameObject gameObject;
	public Text scoreText;
	private int score;

    // Start is called before the first frame update
    void Start()
    {
    	score = 0;
    	scoreText.text = "Score: " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateScore() 
    {
    	scoreText.text = "Score: " + score.ToString();
    }

    public void AddScore(int newScoreValue) 
    {
    	score += newScoreValue;
    	UpdateScore();
    }
}
