using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour

// aqui ficarão as coisas de áudio também
// controla as coisas da cena do jogo

{
    // singleton
   
    #region Singleton
    private static GameController _instance;
    public static GameController Instance 
    {
        get
        {
            // create logic to create the instance
            if (_instance == null)
            {
                GameObject go = new GameObject("GameController");
                go.AddComponent<GameController>();
            }

            return _instance;
        } 
    }
    #endregion

    public delegate void DeadEnemy(); // observer
    public static event DeadEnemy onEnemyDead; // evento do observer inimigo morto

    public delegate void HitEnemy(); // observer
    public static event HitEnemy onEnemyHit; // evento do observer inimigo acertado

    public delegate void TimeIsOver(); // observer
    public static event TimeIsOver onLucioIsComing; // evento do observer tempo acabou - vez do Lúcio

    public delegate void VolumeSoundChange(); // observer
    public static event VolumeSoundChange changingVolumeSound; // evento do observer tempo acabou - vez do Lúcio

	public Text scoreText;
	public Text countdown;

	public float time = 30;
	private int score = 0;

    void Awake() 
    {
        _instance = this;

    }
    // Start is called before the first frame update

    void Start()
    {
    	scoreText.text = "Score: " + score.ToString();
        PauseMenu.GameIsPaused = false;
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
            if (onLucioIsComing != null) 
            {
                onLucioIsComing();
            }
        }
    }

    public void AddScore(int newScoreValue) 
    {
    	score += newScoreValue;
    	UpdateScore();
    }
  
}
