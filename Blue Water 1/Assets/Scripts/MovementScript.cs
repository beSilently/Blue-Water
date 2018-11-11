using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour {

		public float speed = 0.04f;
	
	private void FixedUpdate () {
		this.transform.position = new Vector3 (this.transform.position.x,this.transform.position.y+speed , this.transform.position.z);
	}

}
