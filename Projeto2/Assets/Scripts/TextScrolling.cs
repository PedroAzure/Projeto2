using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextScrolling : MonoBehaviour
{
    public LevelChanger changer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	Vector3 pos = transform.position;

        pos.y += Time.deltaTime * 0.8f;
        Debug.Log(pos.y);
        //Atualiza posição
        transform.position = pos;

        if (pos.y > 14) 
        {
        	changer.FadeToNextLevel();
        }
    }
}
