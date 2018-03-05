using UnityEngine;
using System.Collections;

public class DistanceChecker : MonoBehaviour
{
    float previousPosX;

    private void Start()
    {
        previousPosX = transform.position.x;
    }

    private void Update()
    {
        if (Mathf.Floor(previousPosX) < Mathf.Floor(transform.position.x))
            SpawnManager.instance.SpawnNewRow((int)transform.position.x);

        previousPosX = transform.position.x;
    }
}
