using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class  Target  {

	//static private List<GameObject> targetedObjects = new List<GameObject>();
	//public List<GameObject> TargetedObjects
	//{
		//get
		//{
		//	return targetedObjects;
		//}
		//set
		//{
		//	targetedObjects = value;
		//}
	//}


	// Use this for initialization
	//void Start () {
	
	//}
	// Update is called once per frame
	//void Update () {

		//Debug.Log (targetedObjects.Count);
		/*if (Input.GetButtonDown ("Fire1")) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			Debug.Log ("hello2");
			if (Physics.Raycast (ray, out hit, 100.0f)) {

				Debug.Log ("hello1");
				if (hit.transform == target) {
					Debug.Log ("Hello");
				}
			
			}
			//Debug.Log(hit.collider.name);
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
			
			if(hit.collider != null)
			{
				Debug.Log ("Target Position: " + hit.collider.gameObject.named);
			}
		}*/
	//}
}
