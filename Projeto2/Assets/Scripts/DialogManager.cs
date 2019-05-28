using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogManager : MonoBehaviour
{
    public Image imageDialog;

    //Set this in the Inspector
    public Sprite[] m_Sprite;

    public Animator animator;

    public Dialog dialog;

    string nameScene;

    private Queue<Image> sentences;

    int i = 0;

    void Start()
    {

        sentences = new Queue<Image>();

        nameScene = SceneManager.GetActiveScene().name;

        StartDialog(dialog);

        Debug.Log("start");
    }


    public void StartDialog (Dialog dialog)
    {

        animator.SetBool("IsOpen", true);

        sentences.Clear();

        foreach (Image sentence in dialog.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();  
        
    }

    public void DisplayNextSentence ()
    {
        if (sentences.Count == 0)
        {
            EndDialog();

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            //levelChanger.FadeToNextLevel();
            //Debug.Log("Vá para a próxima cena");

            return;
        }

        Image sentence = sentences.Dequeue();

        imageDialog.sprite = m_Sprite[i];
        i++;

        //Debug.Log("DisplayNextSentence" + i);
    }


    void EndDialog()
    {
        animator.SetBool("IsOpen", false);
    }
}
