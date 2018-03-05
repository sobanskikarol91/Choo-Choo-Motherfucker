using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour 
{
	public GameObject ExplosionEffect;
	public GameObject Player;
	public static Explode instance;
	void Awake () 
	{
		instance = this;
	}
	public void DoExplode()
	{
		Instantiate(ExplosionEffect, Player.GetComponent<Transform>().position,
		 Player.GetComponent<Transform>().rotation);
	}

}
