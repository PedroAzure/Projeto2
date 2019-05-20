using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;

    private int levelToLoad;
    
    // Update is called once per frame
    void Update()
    {
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
        if(SceneManager.GetActiveScene().buildIndex <= 1)
            FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
        else
            FadeToLevel(0);
        
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
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
}
