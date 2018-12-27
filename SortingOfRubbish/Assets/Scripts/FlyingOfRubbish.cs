using UnityEngine;
using System.Collections;


 public class FlyingOfRubbish : MonoBehaviour
{
	Vector3 initialTargetPosition;
	public Vector3 Target{ get; set; }
    bool canMoveToTree = true;
	Vector3 previousPosition;

	void Start ()
	{
		initialTargetPosition = transform.position;
		Target =new Vector3 (initialTargetPosition.x-7.85f,initialTargetPosition.y-3.8f,0);
	}
	
	void Update ()
	{
		if (canMoveToTree) 
		{   previousPosition=transform.position;
			transform.position = Vector3.Lerp (this.transform.position, Target,.012f); 
			if((int)(transform.position.x*1000)/1000f!=(int)(previousPosition.x*1000)/1000f)
		   {
				this.GetComponent<MovementOfRubbish>().movable=false;

			}
			else 
			{
				canMoveToTree=false;
			}

		}
	}
}

