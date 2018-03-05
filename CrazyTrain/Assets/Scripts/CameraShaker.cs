using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    public static CameraShaker instance;
    Vector2 velocity;

    public float smoothTimerX;
    public float smoothTimerY;

    float shakeTimer = 0.4f;
    float skakePower = 0.30f;

    float xBeforeShake;
    float yBeforeShake;
    private void Awake()
    {
        instance = this;
    }

    public void ShakeCamere()
    {
        xBeforeShake = transform.position.x;
        yBeforeShake = transform.position.y;
        StartCoroutine(IEShakeCamera());
    }

    IEnumerator IEShakeCamera()
    {
        float currentShakeTime = shakeTimer;

        while (currentShakeTime >= 0)
        {
            Vector2 ShakePos = Random.insideUnitCircle * skakePower;
            transform.position = new Vector3(transform.position.x + ShakePos.x, transform.position.y + ShakePos.y, transform.position.z);
            currentShakeTime -= Time.deltaTime;
            SmoothFallow();
            yield return null;
        }
    }

    void SmoothFallow()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, xBeforeShake, ref velocity.x, smoothTimerX);
        float posY = Mathf.SmoothDamp(transform.position.y, yBeforeShake, ref velocity.y, smoothTimerY);

        transform.position = new Vector3(posX, posY, transform.position.z);
    }
}
