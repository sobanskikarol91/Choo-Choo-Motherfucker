using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagament : MonoBehaviour
{
    public SpriteRenderer imageHolder;
    public Sprite firstImage;
    public Sprite secondImage;
    public Sprite thirdImage;
    public Sprite forthImage;
    public Sprite fifthImage;
    public Sprite sixthImage;

    int couter = 1;



    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (couter == 1) imageHolder.sprite = secondImage;
            if (couter == 2) imageHolder.sprite = thirdImage;
            if (couter == 3) imageHolder.sprite = forthImage;
            if (couter == 4) imageHolder.sprite = fifthImage;
            if (couter == 5) imageHolder.sprite = sixthImage;
            if (couter == 6) SceneManager.LoadScene("Karol");
            couter++;
        }
    }

}