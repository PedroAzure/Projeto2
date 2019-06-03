using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PopupManager : MonoBehaviour
{
    //public Image imageDialog;
    //public Image socorro;

    //public Text dialogText;
    
    //private Queue<string> sentences;

    //Set this in the Inspector
    //public Sprite[] m_Sprite;

    public Animator animator;

    //public Dialog dialog;

    //string nameScene;

    //private Queue<Image> sentences;

    //int i = 0;

    void Start()
    {
        //Fetch the Image from the GameObject
        //imageDialog = GetComponent<Image>();

        //sentences = new Queue<Image>();

        //nameScene = SceneManager.GetActiveScene().name;

        //StartDialog();
    }

    public void StartDialog ()
    {

        animator.SetBool("IsOpen", true);

        Invoke("EndDialog", 1);
        //animator.SetBool("IsOpen", false);

        //Debug.Log("Starting conv with" + dialog.name);

        //nameText.text = dialog.name;

        /*sentences.Clear();

        foreach (Image sentence in dialog.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();*/
    }

    //public void DisplayNextSentence ()
    //{
        /*if (sentences.Count == 0)
        {
            EndDialog();

            if(nameScene == "Dialog") 
            {
                // chama próxima cena
                Debug.Log("chama próxima cena -> tutorial");
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            }

            return;
        }

        Image sentence = sentences.Dequeue();

        imageDialog.sprite = m_Sprite[i];
        i++;

        //StopAllCoroutines();
        //StartCoroutine(sentence);
        //StartCoroutine(TypeSentence(sentence));
        Debug.Log(i);
    }
/*
    IEnumerator TypeSentence (string sentence)
    {
        dialogText.text = "";

        foreach(char letter in sentence.ToCharArray())
        {
            dialogText.text += letter;
            yield return null;
        }
    }
  */  
    void EndDialog()
    {
        animator.SetBool("IsOpen", false);
    }
}
