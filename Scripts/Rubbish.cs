using UnityEngine;
using System.Collections;

public class Rubbish : MonoBehaviour {

	public delegate void RubbishDelegate(Vector3 position);
	public string TypeOfRubbish;
	public bool DisplayedOnScene;
	Vector3 InitialPosition;
	public event RubbishDelegate Deleted;
	public void Start()
	{
		InitialPosition =this.transform.position;
		DisplayedOnScene = true;

	}
	public void Remove( )
	{  
		Destroy (this.gameObject);
	    GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>().objectsOfGarbage.Remove(this.gameObject);
		if (Deleted != null)
		Deleted(this.InitialPosition);


	}
	public void ReturnInitialPosition()
	{
		this.transform.position = InitialPosition;
		this.GetComponent<MovementOfRubbish> ().movable = false;

	}



}
