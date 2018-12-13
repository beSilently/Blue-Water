using UnityEngine;
using System.Collections;

public class MovementOfParrot : MonoBehaviour 
{


	void Update()
	{

		var targetPosition = new Vector3(-2.61f,1.69f,0);
		transform.position = Vector3.Lerp(this.transform.position, targetPosition, .03f);
	}
}
