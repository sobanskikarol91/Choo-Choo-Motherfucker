using UnityEngine;
using System.Collections;

public class Coal : MonoBehaviour
{
    float coalBonus = 20;
    float currentCoalAmount = 100;
    int maxCoalAmount = 200;
    float speed = 10;
    public AudioSource shovel;

    public SpeedMeter sm;
    private void Update()
    {
        //if (currentCoalAmount <= 0) return;

        DecreaseCoal();
        CheckCauldroneTemperature();
    }

    public void DecreaseCoal()
    {
        currentCoalAmount -= Time.deltaTime * speed;
        sm.Mesure(currentCoalAmount, 0, maxCoalAmount);
        //Debug.Log("coal: " + currentCoalAmount);
    }

    public void CheckCauldroneTemperature()
    {
        if (currentCoalAmount > maxCoalAmount)
            GetComponent<PlayerController>().Death();
        else if (currentCoalAmount <= 0)
        {
            GetComponent<Mover>().ConstantDecreaseVelocity();
            Camera.main.GetComponent<Mover>().ConstantDecreaseVelocity();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "coal")
        {
            currentCoalAmount += coalBonus;
            Destroy(collision.gameObject);
            shovel.Play();
        }
    }
}
