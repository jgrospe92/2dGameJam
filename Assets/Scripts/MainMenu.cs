using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    bool isCredit = false;

    public GameObject credits;
    
    public void StartGame()
    {
        SceneManager.LoadScene("LevelOne");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void toggleCredits()
    {
        if(isCredit == false)
        {
            credits.SetActive(true);
            isCredit = true;

        } else
        {
            credits.SetActive(false);
            isCredit = false;
        }
    }

    public void OpenMainMenu()
    {
        Debug.Log("Open main");
        SceneManager.LoadScene("MainMenu");
 
    }
}
