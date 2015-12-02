using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour 
{
	Move move;
	GameObject prefab;
	GameObject anObject;
	// Use this for initialization
	void Start () 
	{
		prefab = Resources.Load ("OrangeShip") as GameObject;
		anObject = Instantiate(prefab);
		anObject.transform.position = new Vector3(0.0f,0.0f,0.0f);

		move = new Move (anObject);
	}
	
	// Update is called once per frame
	void Update () {

		//Debug.Log (anObject);
		move.shipUpdate ();
	}
}
