using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LucioFase2 : MonoBehaviour
{
    public GameController controller;
    public GameObject player;
    public float playerY;
    public float lucioX;

    public int girls;
    public float timer = 30;

    public bool ida = true;
    public bool reverse = true;

    public Animator seta;
    public bool setaCheck = false;
    //public bool finished = true;
    Vector3 pos;
    

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        pos = new Vector2(-20f, playerY);
    }

    // Update is called once per frame
    void Update()
    {
        girls = controller.GetComponent<Girls>().quantidadeMulheres;

        if (timer >= .5f)
        {
            playerY = player.transform.position.y;
            pos = new Vector2(transform.position.x, playerY);
            
            
        }

        if (timer <= 3f && setaCheck == false)
        {
            if (ida)
                seta.SetTrigger("SetaVindo");
            else
                seta.SetTrigger("SetaDireitaVIndo");
            setaCheck = true;
        }

        if (girls > 0)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0 )
        {
            if (ida)
            {
                if (reverse)
                {
                    pos = new Vector2(-12f, playerY);
                    gameObject.transform.localScale = new Vector2(1f, 1f);
                    reverse = false;
                }

                pos.x += .3f;
                //pos.y = playerY;

                if (pos.x >= 12f)
                {
                    ida = false;
                    timer = 10f;
                    setaCheck = false;
                    //finished = true;
                }
            }

            else 
            {
                if (!reverse)
                {
                    pos = new Vector2(12f, playerY);
                    gameObject.transform.localScale = new Vector2(-1f, 1f);
                    reverse = true;
                    
                    //finished = true;
                }

                Debug.Log("Volta");
                pos.x -= .3f;
                //pos.y = playerY;

                if (pos.x <= -12f)
                {
                    ida = true;
                    timer = 10f;
                    setaCheck = false;
                }
            }   
        }

        transform.position = pos;

    }
}
