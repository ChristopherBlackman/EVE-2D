﻿using UnityEngine;
using System.Collections;

public class Main:MonoBehaviour
	{
	Ship defaultShip;
	Astroid[] astroids;

	// Use this for initialization
	void Start () 
	{
		defaultShip = new Ship ();
		astroids    = (new WorldGen()).genWorld();
	}
	
	// Update is called once per frame
	void Update () 
	{
		defaultShip.shipUpdate ();
	}
}