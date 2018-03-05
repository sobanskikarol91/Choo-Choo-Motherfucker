using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    int points = 0;
    public Text pointsText;
    public Text velocityText;
    public static GameManager instance;
    public Mover mover;

    private void Awake()
    {
        instance = this;
        mover = Camera.main.GetComponent<Mover>();
    }

    public void UpdatePoints()
    {
        Debug.Log(points);
        points+=100;
        pointsText.text = points.ToString();
        pointsText.GetComponent<Animator>().SetTrigger("points");
    }
}
