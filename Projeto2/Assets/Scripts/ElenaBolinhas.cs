using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElenaBolinhas : MonoBehaviour
{
    // quantidade de mulheres capturadas
    private int quantidadeMulheres = 0;

    //Set this in the Inspector
    public Sprite[] m_Sprite;

    GameObject elena;

    PlayerCollision playerCollision;

    // Start is called before the first frame update
    void Start()
    {

        PlayerCollision.elenaGetWoman += ChangeImageBalls;

        elena = GameObject.Find("PlayerShip");

        GetComponent<SpriteRenderer>().sprite = m_Sprite[0];
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = elena.transform.position;
        //transform.rotation = Quaternion.Slerp(0, 0,  Time.deltaTime);

        transform.Rotate(0, 0, Time.deltaTime * 30, Space.Self);


    }

    void ChangeImageBalls ()
    {
     
        quantidadeMulheres++;

        Debug.Log(quantidadeMulheres);

        GetComponent<SpriteRenderer>().sprite = m_Sprite[quantidadeMulheres];

    }

    void LucioColisao() 
    {
        
    }

    void OnDisable() 
    {
        PlayerCollision.elenaGetWoman -= ChangeImageBalls;

        // caso o objeto não exista mais no jogo, a inscrição dele no evento será retirada;
    }
}
