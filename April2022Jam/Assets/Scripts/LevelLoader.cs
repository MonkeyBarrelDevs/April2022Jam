using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class LevelLoader : MonoBehaviour
{
    
    [SerializeField] float transitionDuration = .5f;
    [SerializeField] bool autoTransition = true;
    [SerializeField] float autoTransDelay = 0f;
    [SerializeField] string autoTransTargetScene = "SampleScene";

    private void Start()
    {
        if (autoTransition)
        {
            DelayLoadLevelWithName(autoTransTargetScene, autoTransDelay);
        }
    }

    public string getSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void ReplayTransition()
    {
        StartCoroutine(CycleTransition());
    }

    public void LoadLevelAtIndex(int index)
    {
        StartCoroutine(LoadLevel(index));
    }

    public void LoadLevelWithName(string name)
    {
        StartCoroutine(LoadLevel(name));
    }

    public void DelayLoadLevelWithName(string sceneName, float delay)
    {
        StartCoroutine(Delay(sceneName, delay));
    }

    public void ReloadScene() 
    {
        StartCoroutine(LoadLevel(getSceneName()));
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private void PlayTransition() 
    {
        if (TransitionEvent != null)
            TransitionEvent();
    }

    public static event Action TransitionEvent;

    IEnumerator LoadLevel(int levelIndex)
    {
        PlayTransition();

        yield return new WaitForSeconds(transitionDuration);

        SceneManager.LoadScene(levelIndex);
    }

    IEnumerator LoadLevel(string name)
    {
        PlayTransition();

        yield return new WaitForSeconds(transitionDuration);

        SceneManager.LoadScene(name);
    }

    IEnumerator CycleTransition()
    {
        PlayTransition();

        yield return new WaitForSeconds(transitionDuration);
    }

    IEnumerator Delay(string name, float delay)
    {
        yield return new WaitForSeconds(delay);
        LoadLevelWithName(name);
    }
}