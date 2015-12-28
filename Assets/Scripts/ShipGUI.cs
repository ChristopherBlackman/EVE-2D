using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShipGUI : MonoBehaviour {

    float width;
    float length;
	GameObject aGUI;
    GameObject laSpeed;
    Canvas CanvasForGUI;
	Text txtSpeed;
    // Use this for initialization
    public ShipGUI() : this(600f) { }
    public ShipGUI(float width) : this(width, 400f) { }
    public ShipGUI(float width, float length) : this(width, length, 0f) { }
    public ShipGUI(float width, float length, float marginX) : this(width, length, marginX, 0f) { }
    public ShipGUI(float width, float length, float marginX, float marginY)
	{
		aGUI =Instantiate( Resources.Load ("Ship_GUI") as GameObject);

        laSpeed = aGUI.gameObject.transform.GetChild(0).gameObject;
        aGUI.GetComponent<RectTransform>().sizeDelta = new Vector2(width, length);
        Debug.Log(aGUI.GetComponent<RectTransform>().rect.ToString());
        Debug.Log(aGUI.GetComponent<RectTransform>().sizeDelta.ToString());
        //laSpeed.transform.position = new Vector3(500f,0f, 0f);
        laSpeed.GetComponent<RectTransform>().anchoredPosition = new Vector3(marginX + (width/(-2)), marginY + (length/(-2)), 0f);
        txtSpeed = laSpeed.GetComponent<Text>();
        txtSpeed.resizeTextForBestFit = true;
        txtSpeed.raycastTarget = false;

        //txtSpeed.alignment = 
        //txtSpeed = aGUI..AddComponent<Text>();
        //speed = gameObject.GetComponent<Text>(); 
        //speed.text = "hello";
    }
	public void update(float speed)
	{
        //Debug.Log(aGUI.GetComponents<Text>().Length);
        //Debug.Log(aGUI.GetComponentInChildren<Text>().GetComponent<Text>());
        aGUI.GetComponentInChildren<Text>().text = (Mathf.RoundToInt(speed*1000)).ToString()  +" m/s";
        //txtSpeed.text = " hello";
        //(aGUI.GetComponent ("LocalSpeedOfShip") as Text).text =  "F_Us";
        //(aGUI.GetComponent<Text> ()).text = "F_Us";//speed.ToString();
        //Text[] a = aGUI.GetComponentsInChildren<Text> ();
        //a [0].text = (Mathf.RoundToInt(speed*1000)).ToString () + " m/s";
        //Debug.Log (a.Length);
    }
}
