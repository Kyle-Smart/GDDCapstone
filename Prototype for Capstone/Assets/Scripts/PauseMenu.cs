using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject thePauseMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                UnPause();
            } else
            {
                Pause();
            }
        }
    }

    private void UnPause()
    {
        thePauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    private void Pause()
    {
        thePauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ExitToMainMenu()
    {
        UnPause();
        SceneManager.LoadScene("Main Menu");
    }

    public void ResumeGame()
    {
        UnPause();
    }

    public void ResetLevel()
    {
        UnPause();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
