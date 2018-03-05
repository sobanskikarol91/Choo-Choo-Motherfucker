using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{


    public void StartGame()
    {
            SceneManager.LoadScene("Karol");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }
    
    public void StartScene()
    {
        SceneManager.LoadScene("Start");
    }
    public void StartTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
	
}
