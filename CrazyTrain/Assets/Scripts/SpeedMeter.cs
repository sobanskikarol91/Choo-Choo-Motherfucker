using UnityEngine;
using System.Collections;

public class SpeedMeter : MonoBehaviour
{
    float minAngle = -75;
    float maxAngle = 75f;

    public void Mesure(float speed, float min, float max)
    {
        float ang = Mathf.Lerp(minAngle, maxAngle, Mathf.InverseLerp(max, min, speed)) + Oscylation();
        //Debug.Log("ang" + ang);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, ang);
    }

    int Oscylation()
    {
        return Random.Range(-2, 2);
    }
}
