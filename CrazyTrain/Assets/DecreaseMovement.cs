using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DecreaseMovement : MonoBehaviour {

	// Use this for initialization
 public static DecreaseMovement instance;

  private void Awake() 
  {
	instance = this;
  }
	public void Slow()
	{
		StartCoroutine(IESlow());
	}

    public IEnumerator   IESlow()
    {
       while(Time.timeScale > 0.4f)
       {
           Time.timeScale -= Time.deltaTime/2;
            yield return null;
       }
	   if(Time.timeScale <= 0.4f)
	   {
		   Time.timeScale = 0f;
		   SceneManager.LoadScene("GameOver");
		   Time.timeScale = 1f;
	   }
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
