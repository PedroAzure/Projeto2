using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float maxSpeed;
    public float shipBoundaryRadius;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

 		//Velocidade
        Vector3 pos = transform.position;
        pos.y += Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime; //Movimento Vertical
        pos.x += Input.GetAxis("Horizontal") * maxSpeed * Time.deltaTime; //Movimento Horizontal


        //Restrição de movimento vertical à área da câmera
        //Top
        if(pos.y + shipBoundaryRadius > Camera.main.orthographicSize) {
        	pos.y = Camera.main.orthographicSize - shipBoundaryRadius;
        }

        //Bottom
        if(pos.y - shipBoundaryRadius < -Camera.main.orthographicSize) {
        	pos.y = -Camera.main.orthographicSize + shipBoundaryRadius;
        }

        //Cálculo de resolução
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float widthOrtho = Camera.main.orthographicSize * screenRatio;

        //Restrição lateral de movimento
        //Right
        if(pos.x + shipBoundaryRadius > widthOrtho) {
        	pos.x = widthOrtho - shipBoundaryRadius;
        }

        //Left
        if(pos.x - shipBoundaryRadius < -widthOrtho) {
        	pos.x = -widthOrtho + shipBoundaryRadius;
        }

        //Atualiza posição
        transform.position = pos;
    }

    
}
