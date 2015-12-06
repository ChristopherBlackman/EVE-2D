using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShipGUI : MonoBehaviour {
	
	GameObject aGUI;
	Text speed;
	// Use this for initialization
	public ShipGUI ()
	{
		aGUI =Instantiate( Resources.Load ("Ship_GUI") as GameObject);
		//speed = gameObject.GetComponent<Text>(); 
		//speed.text = "hello";
	}
	public void update(float speed)
	{
		//(aGUI.GetComponent ("LocalSpeedOfShip") as Text).text =  "F_Us";
		//(aGUI.GetComponent<Text> ()).text = "F_Us";//speed.ToString();
		Text[] a = aGUI.GetComponentsInChildren<Text> ();
		a [0].text = (Mathf.RoundToInt(speed*1000)).ToString () + " m/s";
		Debug.Log (a.Length);
	}
}
