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
	void Update () {
		if(Input.GetKeyUp(KeyCode.Mouse1))
		{
			if (targets.Count > 0)
			{
				foreach(GameObject[] apair in targets)
				{
					Destroy(apair[1]);
				}
			}
			targets.Clear();

			Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 mousPos2D = new Vector2 (mousePos3D.x, mousePos3D.y);
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
