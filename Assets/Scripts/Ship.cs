using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour 
{
	private GameObject aShip;
	private Move move;
	private ShipCamera aCameraObject; 
	// Use this for initialization
	void Start () 
	{
		GameObject prefab = Resources.Load ("OrangeShip") as GameObject;
		GameObject prefab1 = Resources.Load ("aCamera") as GameObject;
		aShip = Instantiate(prefab);
		//Camera aCamera = Instantiate(prefab1).GetComponent<Camera> ();
		//aCamera.transform.position = anObject.transform.position;
		//anObject.transform.position = new Vector3(0.0f,0.0f,0.0f);

		//GetComponent<Camera>() = Instantiate (prefab1);
		//GetComponent<Camera>().transform.position = anObject.transform.position;
		aShip.transform.position = new Vector3 (0, 0, 1);
		move = new Move (aShip);
		aCameraObject = new ShipCamera ();

	}
	
	// Update is called once per frame
	void Update () {

		//Debug.Log (anObject);
		move.shipUpdate ();
		aCameraObject.cameraUpdatePos ( new Vector2 (aShip.transform.position.x,aShip.transform.position.y));
		//add camera class that is givin the gameobject pos
	}
}
