using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
    public float speed = -2;
    public float currentSpeed;
    public float slowedTime = 3f;
    public float speedIncreaseSpeed = 3f;
    float maxSpeed = 30;

    bool stop;
    public SpeedMeter sm;

    private void Start()
    {
        StartCoroutine(ConstantIncreaseVelocity());
    }

    private void FixedUpdate()
    {
        if (stop) return;
        float timeAfterStart = 0f;

        if (timeAfterStart < slowedTime && currentSpeed < speed)
        {
            timeAfterStart += Time.deltaTime;
            sm.Mesure(currentSpeed * 2, 0, maxSpeed / 2);
            currentSpeed += speed * timeAfterStart / slowedTime;
        }
        transform.Translate(new Vector3(1, 0, 0) * 0.01f * currentSpeed);
    }

    public IEnumerator ConstantIncreaseVelocity()
    {
        while (true)
        { 
            if (currentSpeed < maxSpeed)
                currentSpeed += Time.deltaTime * speedIncreaseSpeed;

            sm.Mesure(currentSpeed, 0, maxSpeed);
            yield return null;
        }
    }

    public void ConstantDecreaseVelocity()
    {
        stop = true;
        StopAllCoroutines();
        StartCoroutine(IEConstantDecreaseVelocity());
    }

    public IEnumerator IEConstantDecreaseVelocity()
    {
        while (true)
        {
            if (currentSpeed >0 )
                currentSpeed -= Time.deltaTime * speedIncreaseSpeed*30;

            if (currentSpeed < 0)
            {
                currentSpeed = 0;
                break;
            }


            sm.Mesure(currentSpeed, 0, maxSpeed);
            yield return null;
        }
        DecreaseMovement.instance.GameOver();
    }

    public void StopConstantIncreaseVelocity()
    {
        StopAllCoroutines();
    }
}