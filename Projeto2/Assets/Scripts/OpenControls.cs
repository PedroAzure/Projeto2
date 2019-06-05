using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenControls : MonoBehaviour
{
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void fadeControls()
    {
        animator.SetBool("IsOpen", true);
    }

    void hideShot()
    {
        animator.SetBool("IsOpen", false);
        animator.SetBool("ShotHidden", true);
    }
}
