using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;

    public int levelToLoad = 0;

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Time.deltaTime);
        if(Input.touchCount >= 3)
        {
            FadeToNextLevel();
        }
        
    }

    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    public void FadeToNextLevel()
    {
        if(SceneManager.GetActiveScene().buildIndex <= 7)
            FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
        else
            FadeToLevel(0);
        
    }

    public void FadePostDialogue()
    {
        FadeToLevel(6);   
    }

    public void FadeCenaFInal()
    {
        FadeToLevel(7);
    }

    public void OnFadeComplete()
    {
        StartCoroutine(BeginLoad()); 
    }

    public void FadeToHome()
    {
        levelToLoad = 0;
        animator.SetTrigger("FadeOut");
    }

    public void RetryLevel()
    {
        levelToLoad = SceneManager.GetActiveScene().buildIndex;
        Time.timeScale = 1f;
        animator.SetTrigger("FadeOut");
    }

    public void PauseFadeToHome()
    {
        levelToLoad = 0;
        Time.timeScale = 1f;
        animator.SetTrigger("FadeOut");
    }

    public void FadeOutNoChange()
    {
        animator.SetTrigger("FadeOutNoChange");
    }

    public void FinishFade()
    {
        animator.ResetTrigger("FadeOutNoChange");
    }

    /*public void MudarTela(string nomeTela)
    {
        //Começa a função de carregar tela
        StartCoroutine(CarregarTela(nomeTela));
    }

    IEnumerator CarregarTela(string nomeTela)
    {
        //cria uma operação assíncrona para carregar a tela sem travar o jogo
        
        carregando.SetActive(true);//gameobject
        carregando.GetComponent<Animator>().Play(0);
        //enquanto a tela não for carregada
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(nomeTela);
        while (!asyncLoad.isDone)
        {
            //Não faça nada
            yield return null;
        }
        //Depois que a cena for carregada
    }*/

    IEnumerator BeginLoad()
    {
        Debug.Log(levelToLoad);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(levelToLoad);

        while (!asyncLoad.isDone)
        {
            //Não faça nada
            yield return null;
        }
    }
}
