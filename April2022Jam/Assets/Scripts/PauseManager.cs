using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    LevelLoader loader;

    private void Start()
    {
        Time.timeScale = 1f;
        loader = FindObjectOfType<LevelLoader>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel")) 
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void Resume() 
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ReturnToMenu() 
    {
        loader.LoadLevelWithName("Main Menu");
    }
}
