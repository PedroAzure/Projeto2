using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitFlash : MonoBehaviour
{
    public GameObject image;

    private Color32 currentColor;

    private void Start()
    {
        currentColor = image.GetComponent<Image>().color;
    }

    void hit()
    {
        image.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
        Invoke("colorBack", .3f);
    }

    void colorBack()
    {
        image.GetComponent<Image>().color = currentColor;
    }
}
