using UnityEngine;
using System.Collections;

public class Main:MonoBehaviour
	{
	Ship defaultShip;

	// Use this for initialization
	void Start () 
	{
		defaultShip = new Ship ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		defaultShip.shipUpdate ();
	}
}