using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cutscene : MonoBehaviour
{
    public Image imageDialog;

    public AudioClip[] MusicClip;
    public AudioSource MusicSource;

    //Set this in the Inspector
    public Sprite[] m_Sprite;

    public Animator animator;

    public Animator shipAnimator;

    public Dialog dialog;

    string nameScene;

    private Queue<Image> sentences;

    public LevelChanger changer;

   

    int i = 0;

    void Start()
    {
        sentences = new Queue<Image>();

        nameScene = SceneManager.GetActiveScene().name;

        StartDialog2(dialog);

        Debug.Log("start");
    }


    public void StartDialog2 (Dialog dialog)
    {

        animator.SetBool("IsOpen", true);

        sentences.Clear();

        foreach (Image sentence in dialog.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence2();  
        
    }

    public void DisplayNextSentence2 ()
    {
        if (sentences.Count == 0)
        {
            EndDialog2();

            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            
            //Debug.Log("Vá para a próxima cena");

            return;
        }

        Image sentence = sentences.Dequeue();

        MusicSource.clip = MusicClip[i];
        MusicSource.Play();

        imageDialog.sprite = m_Sprite[i];
        i++;

        //Debug.Log("DisplayNextSentence" + i);
    }


    void EndDialog2()
    {
        animator.SetBool("IsOpen", false);
        shipAnimator.SetBool("Finished", true);

        //changer.FadeToNextLevel();
    }

}
