using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TargetManager : MonoBehaviour {
	GameObject prefab;
	GameObject[] pair = new GameObject[2];
	List<GameObject[]> targets = new List<GameObject[]>();
	GameObject target = null;

	// Use this for initialization
	void Start () {
		prefab = Resources.Load ("Target") as GameObject;
	}


	// Update is called once per frame
	//would like to start getting rid of gameobjects and replaing classes so that this class will only get but will not be able to set anything exept for the targets prefab
	void Update ()
	{
		//get rid of all the targets on screen
		if(Input.GetKeyUp(KeyCode.Mouse1))
		{
			if (targets.Count > 0)
			{
				foreach(GameObject[] apair in targets)
				{
					Destroy(apair[1]);
				}
			}
			//clear the lists
			targets.Clear();

			//use the camera pos of current ship object ( change ) ***
			Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 mousPos2D = new Vector2 (mousePos3D.x, mousePos3D.y);
			//make custom code for this maybe
			RaycastHit2D hit = Physics2D.Raycast(mousPos2D, Vector2.up);
		

			if(hit.collider)
			{
				pair[0] = hit.collider.gameObject;
				GameObject anObject = Instantiate(prefab);
				pair[1] = anObject;
				targets.Add(pair);
				//go.transform.position = hit.collider.gameObject.transform.localPosition;
			}
		}
		foreach (GameObject[] reticule in targets)
		{
			reticule[1].transform.position = reticule[0].transform.localPosition;
		}
	}
}
