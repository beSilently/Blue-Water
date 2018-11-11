using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandleScript : MonoBehaviour
{  

	Vector3 mouseStartPos;
	Vector3 playerStartPos;
	public void FixedUpdate()
	{
		if (Input.GetMouseButtonDown (0)) 
		{
			mouseStartPos = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0));
			mouseStartPos.x= DeterminePositionOfX(mouseStartPos.x);


			playerStartPos = this.transform.position;
		}
		if (Input.GetMouseButton (0)) 
		{   
			Vector3 mousePos = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0));
			mousePos.x= DeterminePositionOfX(mousePos.x);
			Vector3 move = mousePos - mouseStartPos;
			this.transform.position = playerStartPos + move;
		}
		else 
		{
			this.transform.position += new Vector3(0, Camera.main.GetComponent<MovementScript>().speed, 0);

		}
	}
	public float DeterminePositionOfX(float pos)
	{   float radiusOfHandleObject = this.GetComponent<CircleCollider2D> ().radius;
		float Xmax = GameObject.FindGameObjectWithTag("Background").GetComponent<EdgesOfObjectForX>().Xmax -radiusOfHandleObject;
		float Xmin = GameObject.FindGameObjectWithTag("Background").GetComponent<EdgesOfObjectForX>().Xmin + radiusOfHandleObject;
		if (pos < Xmin) 
		{
			return Xmin;
		}
		else if (pos > Xmax)
		{
			return Xmax;
		}
		return pos;
	}

}