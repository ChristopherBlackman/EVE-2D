using UnityEngine;
using System.Collections;
//add a function that creates acceleration and deceleration adding to whe it turns and does not turn
class Move
{

	private bool turn ;
	private float transverseSpeed ;
    private const float TRASVERSE_MAX = 1f;
	private float turnAngle ;
	private float deltaAngle;
	private bool oneClick;
	private float timeLeftOfClick;
	private float speed;
	private GameObject a;

	public Move() 
	{	
		turn = false;
		transverseSpeed = 1.5f;
		turnAngle = 0.1f;
		oneClick= false;
		timeLeftOfClick = 0.0f;
		speed = 0.0f;
	}
	public Move(GameObject j) 
	{	
		turn = false;
		transverseSpeed = 1.5f;
		turnAngle = 0.1f;
		oneClick= false;
		timeLeftOfClick = 0.0f;
		speed = 0.0f;
		a = j;
		//Debug.Log(a.transform.Find("/OrangeShip/aShip"));

		
	}
	// Update is called once per frame
	public void shipUpdate () 
	{
		//Debug.Log (a);
		ajustSpeed ();
		turnShip(doubleClick());
		moveShip ();


	}

	public float getSpeed()
	{
		return speed;
	}
	
	private void ajustSpeed()
	{
		//check keys 'w' and 's' to increase speed or decrease speed
		if (Input.GetKey (KeyCode.W)) 
		{
			speed = (speed + 0.001 > 0.1)? speed = 0.1f : speed + 0.001f;
		}
		if (Input.GetKey (KeyCode.S))
		{
			speed = (speed - 0.001 <= 0 )? speed = 0.0f : speed - 0.001f;
		}
	}
	private void turnShip(bool doubleClick)
	{
		//get angle of the ship current
		float angleBefore = a.transform.rotation.eulerAngles.z;

		//if there is a double click re-evaluate the turn
		if (doubleClick) 
		{
			//get the  new current pos of the mouse
			var mouse = Input.mousePosition;
			//got the curent location of the ship
			var screenPoint = Camera.main.WorldToScreenPoint(a.transform.localPosition);
			//find the vector of the ship to the new point
			var offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
			//font the angle of that vector
			var angle = (Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg )-90;
			// set the new angle to turn
			turnAngle = angle;
			//find one angle possible
			float deltaAngle1 = angleBefore - angle;
			//find the second angle that is possible
			float deltaAngle2 = (deltaAngle1 > 0) ? deltaAngle1 - 360 : deltaAngle1 + 360;
			//deteermine which delta angel to use
			bool delta = (deltaAngle1 > 0) ? (deltaAngle1 < -deltaAngle2) : ( -deltaAngle1 < deltaAngle2);
			//acording to the delta chose the angle
			deltaAngle = (delta)? deltaAngle1 : deltaAngle2;

			//make sure to turn
			turn = true;

			//find which directio to turn
			transverseSpeed = (deltaAngle > 0 ) ? -TRASVERSE_MAX : TRASVERSE_MAX;
		}

		//determines if the ship should continue the turn or not
		if (turn)
		{
            bool continueTurn = !(deltaAngle > -2 && deltaAngle < 2);
			
			if (continueTurn)
			{
                //finds the ratio of a f(x) being speed
                //f(x) = x / 100
                //g(x) = a  * f(x)
                float speedRatio = speed * 22.24f;
                //note* x = g(x) and g(x) is ajusted speed
                //f(x) = ( 1/3 * x^3 ) - ( 3/2 * x^2 ) + (2 * x)
                float changeInAngle = (Mathf.Pow(speedRatio, 3) / 3) - (Mathf.Pow(speedRatio, 2) * 3 / 2) + 2 * speedRatio + 0;
                Debug.Log(transverseSpeed);

                a.transform.rotation = Quaternion.Euler(0, 0, angleBefore + transverseSpeed*changeInAngle);
                deltaAngle = deltaAngle + transverseSpeed * changeInAngle;

                //a.transform.rotation = Quaternion.Euler(0, 0, angleBefore + transverseSpeed*speed);
				//deltaAngle= deltaAngle + transverseSpeed*transverseSpeed * speed;
				//moveShip();
			}
			else
			{
				a.transform.rotation = Quaternion.Euler(0, 0, turnAngle);
				turn = false; 
			}
		}
	}
	private bool doubleClick()
	{	
		//check for a single click or a double click
		if (Input.GetButtonDown ("Fire1")) 
		{
			//mark when first click has been made
			if (!oneClick)
			{
				oneClick = true;
				timeLeftOfClick = Time.time + 1.5f;
				return false;
			}
			//if the time has gone over then reset
			else if (timeLeftOfClick < Time.time)
			{
				oneClick = false;
				return false;
			}
			//if the time still has not gone over then it is a double click
			else if (timeLeftOfClick > Time.time)
			{
				oneClick = false;
				timeLeftOfClick = 0.0f;
				return true;
			}
		}
		return false;
	}

	private void moveShip()
	{
		//if the ship is turning then slow the ship down

		if (turn && speed > 0.06) 
		{
            speed = speed * 0.9980f;
		}
        if(turn && speed < 0.02)
        {
            speed = -1f * (speed + 0.001f) * (speed - 0.02f) + speed;
        }
		a.transform.position = a.transform.position + a.transform.TransformVector (0, speed, 0);
	}


}
