using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Girls : MonoBehaviour
{

    public GameObject girlPrefab;

    public GameController controller;

    public float girlRate = 5;
    float nextGirl;
    public int nextGirlType = 1;

    public int maxGirlTypes = 1;

    public float numberOfEnemies = 0;

    private int quantidadeMulheres = 0;

    //Set this in the Inspector
    public Sprite[] m_SpriteWomen;


    // Start is called before the first frame update
    void Start()
    {
        PlayerCollision.elenaGetWoman += ChangeImageWoman;

        girlPrefab.GetComponent<SpriteRenderer>().sprite = m_SpriteWomen[0];

        nextGirl = girlRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.spawner.Equals("SPAWNING"))
            {

            nextGirl -= Time.deltaTime;

            if(nextGirl <= 0) 
            {
                
                nextGirl = girlRate;

                Vector3 position = new Vector3(11, Random.Range(-4.4f, 4.3f), 0);

                girlPrefab.GetComponent<SpriteRenderer>().sprite = m_SpriteWomen[Random.Range(0, 4)];

                Instantiate(girlPrefab, position, Quaternion.identity);

            } 
        }
    }

    void ChangeImageWoman ()
    {
    
        if (quantidadeMulheres < 8)  
        {
            quantidadeMulheres++;

            Debug.Log(quantidadeMulheres);
        }

    }

    void OnDisable() 
    {
        PlayerCollision.elenaGetWoman -= ChangeImageWoman;

        // caso o objeto não exista mais no jogo, a inscrição dele no evento será retirada;
    }
}
