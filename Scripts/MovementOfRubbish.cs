using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementOfRubbish: MonoBehaviour
{  
	Vector3 mouseStartPos;
	Vector3 playerStartPos;
	public bool movable=false;



	public void Update()
	{
		if (Input.GetMouseButtonDown (0) ) 
		{
			mouseStartPos = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0));
			playerStartPos = this.transform.position; 

	    }


		if (Input.GetMouseButton (0) && movable) 
		{   
			Vector3 mousePos = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0));
			Vector3 move = mousePos - mouseStartPos;
			this.transform.position = new Vector3(DeterminePositionOfX(playerStartPos.x+move.x), DeterminePositionOfY(playerStartPos.y + move.y),0);
			}

		}

	public void OnMouseEnter ()
	{   
		if ( !Input.GetMouseButton (0) )
		{  
			for (int i=0; i<GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>().objectsOfGarbage.Count; i++) 
			{
				GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>().objectsOfGarbage[i].GetComponent<MovementOfRubbish>().movable=false;

			}
		}
		bool movableOfOther = false;
		for (int i=0; i<GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>().objectsOfGarbage.Count; i++) 
		{
			movableOfOther =GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>().objectsOfGarbage[i].GetComponent<MovementOfRubbish>().movable;
			if(movableOfOther)

				break;

		}
		if (!movableOfOther) 
		{
			movable = true;
		}

	}

	public float DeterminePositionOfX(float pos)
	{  
		float Xmax = GameObject.FindGameObjectWithTag("Background").GetComponent<EdgesOfObject>().Xmax;
		float Xmin = GameObject.FindGameObjectWithTag("Background").GetComponent<EdgesOfObject>().Xmin;
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

	public float DeterminePositionOfY(float pos)
	{  
		float Ymax = GameObject.FindGameObjectWithTag("Background").GetComponent<EdgesOfObject>().Ymax;
		float Ymin = GameObject.FindGameObjectWithTag("Background").GetComponent<EdgesOfObject>().Ymin;
		if (pos < Ymin) 
		{
			return Ymin;
		}
		else if (pos > Ymax)
		{
			return Ymax;
		}
		return pos;
	}

	}


