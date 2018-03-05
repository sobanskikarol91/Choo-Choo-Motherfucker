using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class PlayAgain : MonoBehaviour 
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            SceneManager.LoadScene("Start");
    }
}
