using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogManagerDois : MonoBehaviour
{
    public Image imageDialog;

    //public Text dialogText;
    
    //private Queue<string> sentences;

    //Set this in the Inspector
    public Sprite[] m_Sprite;

    public Animator animator;

    public Dialog dialog;

    string nameScene;

    private Queue<Image> sentences;

    int i = 0;

    private float time = 0;

    void Start()
    {
        //Fetch the Image from the GameObject
        //imageDialog = GetComponent<Image>();

        sentences = new Queue<Image>();

        nameScene = SceneManager.GetActiveScene().name;

        StartDialog(dialog);
    }

    void Update()
    {
    	if (sentences.Count == 0)
        	{
        		DisplayNextSentence();
        	} else {
    	UpdateTime(); }   
    }

    void UpdateTime() 
    {
    	if(time <= 0) 
    	{
            
    	    //countdown.text = "Time: " + time.ToString("f0");

    	    Image sentence = sentences.Dequeue();

	        imageDialog.sprite = m_Sprite[i];
	        i++;

	        

        	time = 4;
    		
    	} else {
    		time -= Time.deltaTime;
    	}
    }

    public void StartDialog (Dialog dialog)
    {
        animator.SetBool("IsOpen", true);

        //Debug.Log("Starting conv with" + dialog.name);

        //nameText.text = dialog.name;

        sentences.Clear();

        foreach (Image sentence in dialog.sentences)
        {
            sentences.Enqueue(sentence);
        }

        
    }

    public void DisplayNextSentence ()
    {
        
            EndDialog();

            if(nameScene == "Dialog") 
            {
                // chama próxima cena
                Debug.Log("chama próxima cena -> tutorial");
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            }

            return;
      

        //Image sentence = sentences.Dequeue();

        //imageDialog.sprite = m_Sprite[i];
        //i++;

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
