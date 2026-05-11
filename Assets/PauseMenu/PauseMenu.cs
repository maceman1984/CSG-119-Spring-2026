using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public List<GameObject> pauseObjects;
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void PauseGame()
    {
        foreach(GameObject pauseObj in pauseObjects)
        {
            pauseObj.gameObject.SetActive(false);
        }
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        foreach (GameObject pauseObj in pauseObjects)
        {
            pauseObj.gameObject.SetActive(true);
        }
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
}
