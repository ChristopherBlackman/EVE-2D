using UnityEngine;
using System.Collections;

public class Astroid :MonoBehaviour
{

	private string type;
	private GameObject astroid;
	private Vector2 locationInfo;
	private float volume;
	// Use this for initialization
	public Astroid () : this ("Gold", new Vector2(0,0)){}
	public Astroid (string aType):this(aType,new Vector2(0,0)){}
	public Astroid (string aType,Vector2 posistion)
	{
		type = aType;
		locationInfo = posistion;

		astroid = Instantiate (Resources.Load ("Astroid_" + type) as GameObject);
		astroid.transform.position = locationInfo;

		volume = Random.Range (500, 1000);
		//volume = new Random () * 100 + 1;
	}
	public void upadatePos (Vector2 x)
	{
		locationInfo = x;
		astroid.transform.position = locationInfo;
	}
	public Vector2 getPos ()
	{
		return locationInfo;
	}
}
