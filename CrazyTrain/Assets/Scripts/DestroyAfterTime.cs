﻿using UnityEngine;
using System.Collections;

public class DestroyAfterTime : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 10);
    }

}