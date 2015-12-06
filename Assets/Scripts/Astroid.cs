using UnityEngine;
using System.Collections;

public class Astroid : MonoBehaviour {

	private string Type;
	private GameObject astroid;
	private Vector2 LocationInfo;
	private float volume;
	// Use this for initialization
	public Astroid () : this ("Gold", new Vector2(0,0)){}

	public Astroid (string a,Vector2 b)
	{
		Type = a;
		LocationInfo = b;
		astroid.transform.position = b;
		astroid = Instantiate (Resources.Load ("Astroid_" + a) as GameObject);
		//volume = new Random () * 100 + 1;
	}
	public void upadatePos (Vector2 x)
	{
		LocationInfo = x;
		astroid.transform.position = LocationInfo;
	}
	public Vector2 getPos ()
	{
		return LocationInfo;
	}
}
