﻿using UnityEngine;
using System.Collections;

public class WorldGen
{
	private float seed;
	private int numberOfObjects;
	// Use this for initialization
	public WorldGen():this(1f){}
	public WorldGen(float aSeed):this(aSeed,2){} 
	public WorldGen(float aSeed, float density)
	{
		seed = aSeed;
		numberOfObjects = (int)(density*1000);
	}
	public Astroid[] genWorld()
	{
		Astroid[] a = new Astroid[numberOfObjects];
		Random r = new Random();

		for (int i= 0; i < a.Length; i++)
		{
			a[i] = new Astroid("Gold",new Vector2 ( Random.Range(-1000,1000), Random.Range(-1000,1000)));
		}
		return a;
	}
}