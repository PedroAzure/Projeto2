using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogText;
    private Queue<string> sentences;

    public Animator animator;

    public Dialog dialog;

    string nameScene;

    void Start()
    {
        sentences = new Queue<string>();

        nameScene = SceneManager.GetActiveScene().name;

        StartDialog(dialog);
    }

    public void StartDialog (Dialog dialog)
    {
        animator.SetBool("IsOpen", true);

        Debug.Log("Starting conv with" + dialog.name);

        nameText.text = dialog.name;

        sentences.Clear();

        foreach (string sentence in dialog.sentences)
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

            if(nameScene == "Dialog") 
            {
                // chama próxima cena
                Debug.Log("chama próxima cena -> tutorial");
            }

            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogText.text = "";

        foreach(char letter in sentence.ToCharArray())
        {
            dialogText.text += letter;
            yield return null;
        }
    }

    void EndDialog()
    {
        animator.SetBool("IsOpen", false);
    }
}
