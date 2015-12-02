using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	public float cameraDistance = 5.0f; 
	// Update is called once per frame
	void Update () {
		cameraDistance = cameraDistance + Input.GetAxis ("Mouse ScrollWheel");

		//var camera = GetComponent<Camera> ();

		//camera.orthographicSize = 1.0f;
		if (cameraDistance < 2.0f)
			cameraDistance = 2.0f;
		Camera.main.orthographicSize = cameraDistance;
		Camera.main.transform.position = new Vector3 (transform.position.x,transform.position.y ,-1.0f);
	}
}
