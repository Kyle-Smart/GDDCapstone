using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsButtons : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
