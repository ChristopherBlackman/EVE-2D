using UnityEngine;
using System.Collections;

public class Ship:MonoBehaviour
{
	private GameObject aShip;
	private Move move;
	private ShipCamera aCameraObject; 
	// Use this for initialization
	public Ship() 
	{
		GameObject prefab = Resources.Load ("OrangeShip") as GameObject;
		GameObject prefab1 = Resources.Load ("aCamera") as GameObject;

		aShip = Instantiate(prefab);
		aShip.transform.position = new Vector3 (0, 0, 1);
		move = new Move (aShip);
		aCameraObject = new ShipCamera ();

	}
	
	// Update is called once per frame
	public void shipUpdate ()
	{

		//Debug.Log (anObject);
		move.shipUpdate ();
		aCameraObject.cameraUpdatePos ( new Vector2 (aShip.transform.position.x,aShip.transform.position.y));
		//add camera class that is givin the gameobject pos
	}
}
