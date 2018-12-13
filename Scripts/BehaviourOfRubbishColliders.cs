using UnityEngine;
using System.Collections.Generic;

public class BehaviourOfColliders : MonoBehaviour {


	void Start () {
		GameManager mngr = new GameManager ();
		List<GameObject> objectsOfGarbage = mngr.objectsOfGarbage;

		for (int i=0; i<objectsOfGarbage.Count; i++) 
		{
			for(int k=i+1;k<objectsOfGarbage.Count;i++)
			{
				Physics.IgnoreCollision(objectsOfGarbage[i].GetComponent<Collider>(),objectsOfGarbage[k].GetComponent<Collider>());
			}
		}
	}
	


}
