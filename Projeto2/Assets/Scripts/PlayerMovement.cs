using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float maxSpeed;
    public float shipBoundaryRadius;

    public Joystick joystick;

    public Animator animator;

    void Update()
    {
        if(!animator.GetBool("Locked"))
        {
            //Velocidade
            Vector3 pos = transform.position;
            //pos.y += Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime; //Movimento Vertical
            //pos.x += Input.GetAxis("Horizontal") * maxSpeed * Time.deltaTime; //Movimento Horizontal

            if(joystick.Horizontal >= .05f)
            {
                pos.x += joystick.Horizontal * maxSpeed * Time.deltaTime;
            } 
            
            else if(joystick.Horizontal <= -.05f)
            {
                pos.x -= -joystick.Horizontal * maxSpeed * Time.deltaTime;
            }
            
            if(joystick.Vertical >= .15f)
            {
                pos.y += joystick.Vertical * maxSpeed * Time.deltaTime;
                animator.SetBool("MoveUp", true);
                animator.SetBool("MoveDown", false);
            }
        
            else if(joystick.Vertical <= -.15f)
            {
                pos.y -= -joystick.Vertical * maxSpeed * Time.deltaTime;
                animator.SetBool("MoveDown", true);
                animator.SetBool("MoveUp", false);

            }

            else if(joystick.Vertical > -.15f && joystick.Vertical < .15f) 
            {
                if(animator.GetBool("MoveUp"))
                {
                    animator.SetBool("Neutral", true);
                }

                if(animator.GetBool("MoveDown"))
                {
                    animator.SetBool("Neutral", true);
                }
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
    
    public void finishedAnimating()
    {
        animator.SetBool("MoveUp", false);
        animator.SetBool("MoveDown", false);
        animator.SetBool("Neutral", false);
    }

    public void finishedEntering()
    {
        animator.SetBool("Locked", false);
    }
}
