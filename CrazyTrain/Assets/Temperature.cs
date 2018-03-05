using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Temperature : MonoBehaviour 
{
	public Transform arm;
	public const float degrees = 360f / 60f;
	float time = 0;
	public float energyUseSpeed = 3f;
	private const float secondsToDegrees = 360f / 60f;
	
	void Update()
	{
		time += Time.deltaTime;
		arm.localRotation = Quaternion.Euler(0f, 0f, energyUseSpeed * time * secondsToDegrees);
	}

}
