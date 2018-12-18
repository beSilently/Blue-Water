using UnityEngine;
using System.Collections;

public class FlyingOfParrot : MonoBehaviour 
{  
	public delegate void FlightOfParrot(Vector3 position);
	public event FlightOfParrot flightUp;
	public bool canFlyToTree;
	public bool canFlyFromTree;
	public bool flapWings = true;
	Vector3 initialTargetPosition;
	Vector3 secondTargetPosition;
	Vector3 currentTargetPosition;
	Vector2 previousPosition;
	GameObject spriteOfSittingParrot;

	public void Start()
	{
		canFlyToTree =true;
		canFlyFromTree = false;
		initialTargetPosition = transform.position;
		secondTargetPosition = new Vector3 (initialTargetPosition.x-7.85f,initialTargetPosition.y-3.8f,0);
		spriteOfSittingParrot=(GameObject)Resources.Load ("Parrot3");

	}
	public void Update()
	{
		if (canFlyToTree)
		{   canFlyFromTree=false;
			flapWings=true;
			Fly(secondTargetPosition);
		    
		}

		if (canFlyFromTree) { 
			Fly (initialTargetPosition);

		}


	}

	public void Fly(Vector3 target)
	{   
		previousPosition = transform.position; 
		transform.position = Vector3.Lerp(this.transform.position, target, .012f);
		if ((int)(transform.position.x*1000)/1000f==(int)(previousPosition.x*1000)/1000f) 
		{   flapWings=false;
			this.GetComponent<SpriteRenderer>().sprite=spriteOfSittingParrot.GetComponent<SpriteRenderer>().sprite;
			if (canFlyToTree == false)
			{
				if (flightUp != null)
		        flightUp(new Vector3(4.84f,5.4f,0));
				canFlyToTree=true;
			}
		     
		}

	}


}