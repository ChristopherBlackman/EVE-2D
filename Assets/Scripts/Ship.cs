using UnityEngine;

public class Ship:MonoBehaviour
{
	private Vector2 currentPos;
	private GameObject aShip;
	private Move move;
	private ShipCamera aCameraObject; 
	private ShipGUI aGUI;
	// Use this for initialization
	public Ship() 
	{
		GameObject prefab = Resources.Load ("OrangeShip") as GameObject;
		GameObject prefab1 = Resources.Load ("aCamera") as GameObject;

        aGUI = new ShipGUI(600f, 400f);
		aShip = Instantiate(prefab);
		aShip.transform.position = new Vector3 (0, 0, 1);
		move = new Move (aShip);
		aCameraObject = new ShipCamera ();

	}
	
	// Update is called once per frame
	public void shipUpdate ()
	{

		currentPos = new Vector2 (aShip.transform.position.x, aShip.transform.position.y);
		move.shipUpdate ();
		aCameraObject.cameraUpdatePos (currentPos);
		aGUI.update (move.getSpeed ());
		//add camera class that is givin the gameobject pos
	}
}
