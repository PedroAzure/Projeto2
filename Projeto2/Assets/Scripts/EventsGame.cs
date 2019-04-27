using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsGame : MonoBehaviour
    // aqui estão os eventos que são comuns a todos no jogo
{
    // Start is called before the first frame update
    void Start()
    {
        GameController.onLucioIsComing += changeScene;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void changeScene() 
    {

    	Debug.Log("Chegou o Lúcio. Tempo acabou!");
        Destroy(gameObject);

    }

    void OnDisable() 
    {
    	GameController.onLucioIsComing -= changeScene; 
    	// caso o objeto não exista mais no jogo, a inscrição dele no evento será retirada;
    }
}
