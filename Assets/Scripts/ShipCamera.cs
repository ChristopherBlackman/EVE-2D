using UnityEngine;
using System.Collections;

class ShipCamera : MonoBehaviour {

	private Camera aCamera;
	private float cameraDistance = 5.0f; 
	// Use this for initialization
	public ShipCamera () 
	{
		aCamera = Instantiate ((Resources.Load ("aCamera") as GameObject)).GetComponent<Camera> ();
	}
	public ShipCamera(Camera a)
	{
		aCamera = a;
	}
	
	public void cameraUpdatePos (Vector2 a)
	{
		cameraDistance = cameraDistance + Input.GetAxis ("Mouse ScrollWheel");

		//var camera = GetComponent<Camera> ();

		//camera.orthographicSize = 1.0f;
		if (cameraDistance < 2.0f)
			cameraDistance = 2.0f;
		aCamera.orthographicSize = cameraDistance;
		aCamera.transform.position = new Vector3 (a.x,a.y ,-1.0f);
	}
}
