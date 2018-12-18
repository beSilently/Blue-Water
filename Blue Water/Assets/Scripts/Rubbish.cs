using UnityEngine;
using System.Collections;

public class Rubbish : MonoBehaviour {

	public delegate void RubbishDelegate(Vector3 position);
	public string TypeOfRubbish;
	public bool DisplayedOnScene;
	public  Vector3 InitialPosition;
	public event RubbishDelegate Deleted;
	public virtual void Start()
	{	
		InitialPosition =transform.position;
		DisplayedOnScene = true;

	}
	public virtual void Remove( )
	{   	
      GameObject.FindGameObjectWithTag ("Manager").GetComponent<GameManager1> ().scores += 100;
     // Debug.Log ("yyyyyyyyy");
	  Destroy (this.gameObject);
	  GameObject.FindGameObjectWithTag ("Manager").GetComponent<GameManager1> ().objectsOfGarbage.Remove (this.gameObject);
	  if (Deleted != null)
	  Deleted (this.InitialPosition);
	
	}
	public void ReturnInitialPosition()
	{
		this.transform.position = InitialPosition;
		this.GetComponent<MovementOfRubbish> ().movable = false;
		GameObject.FindGameObjectWithTag ("Manager").GetComponent<GameManager1> ().scores -= 25;
	}



}
