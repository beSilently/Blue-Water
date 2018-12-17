using UnityEngine;
using System.Collections;

public class ParrotsRubbish : Rubbish
{


	public override void  Start ()
	{
		InitialPosition = this.GetComponent<FlyingOfRubbish> ().Target;
		DisplayedOnScene = true;
	}
	
	public void Remove1 ()
	{  
		Destroy (this.gameObject);
		GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>().objectsOfGarbage.Remove(this.gameObject);
		GameObject.FindGameObjectWithTag ("Manager").GetComponent<GameManager> ().scores += 100;

		GameObject.FindGameObjectWithTag ("Parrot").GetComponent<FlyingOfParrot> ().canFlyFromTree = true;
		GameObject.FindGameObjectWithTag ("Parrot").GetComponent<FlyingOfParrot> ().canFlyToTree = false;
		GameObject.FindGameObjectWithTag ("Parrot").GetComponent<FlyingOfParrot> ().flapWings = true;
	}


}

