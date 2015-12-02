using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour 
{
	Move move;
	GameObject anObject;
	GameObject anObject2;
	// Use this for initialization
	void Start () 
	{
		GameObject prefab = Resources.Load ("OrangeShip") as GameObject;
		GameObject prefab1 = Resources.Load ("aCamera") as GameObject;
		anObject = Instantiate(prefab);
		anObject2 = Instantiate (prefab1);
		anObject.transform.position = new Vector3(0.0f,0.0f,0.0f);
		anObject2.transform.position = anObject.transform.position;

		move = new Move (anObject);
	}
	
	// Update is called once per frame
	void Update () {

		//Debug.Log (anObject);
		move.shipUpdate ();
		//add camera class that is givin the gameobject pos
	}
}
