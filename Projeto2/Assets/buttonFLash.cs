using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonFLash : MonoBehaviour
{
    public Image next;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void nextOpen()
    {
        next.enabled = true;
    }

    void nextIdle()
    {
        //var tempColor = next.color;
        next.enabled = false;
        //tempColor.a = 0f;
        //next.color = tempColor;
    }
}
