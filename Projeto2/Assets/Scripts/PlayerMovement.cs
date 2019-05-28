using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float maxSpeed;
    public float shipBoundaryRadius;

    public Joystick joystick;

    void Update()
    {

 		//Velocidade
        Vector3 pos = transform.position;
        //pos.y += Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime; //Movimento Vertical
        //pos.x += Input.GetAxis("Horizontal") * maxSpeed * Time.deltaTime; //Movimento Horizontal

        if(joystick.Horizontal >= .05f)
        {
            pos.x += joystick.Horizontal * maxSpeed * Time.deltaTime;
        } else if(joystick.Horizontal <= -.05f)
        {
            pos.x -= -joystick.Horizontal * maxSpeed * Time.deltaTime;
        }

        if(joystick.Vertical >= .05f)
        {
            pos.y += joystick.Vertical * maxSpeed * Time.deltaTime;
        } else if(joystick.Vertical <= -.05f)
        {
            pos.y -= -joystick.Vertical * maxSpeed * Time.deltaTime;
        }

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
