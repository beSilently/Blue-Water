using UnityEngine;
using System.Collections;

public class RubbishBin : MonoBehaviour {

	Command command; 

	bool PosibilityOfRemoving=false;

	public string TypeOfRubbish;


	 void Update()
	{  
	  if (Input.GetMouseButtonUp (0))
		{   
			if (command != null ) 
			{
				if(PosibilityOfRemoving)
				{
					command.Execute ();
				}

				else 
				{
					command.Undo ();
					
				}
				command = null;
				PosibilityOfRemoving = false;
			}
	    }
	}
	public void OnCollisionEnter2D(Collision2D col)
	{ 
		if (TypeOfRubbish == col.gameObject.GetComponent<Rubbish> ().TypeOfRubbish) 
		{

			PosibilityOfRemoving=true;
		} 

		SetCommand (new RemovingOfRubbish (col.gameObject.GetComponent<Rubbish> ()));

	}

	public void OnCollisionExit2D(Collision2D col)
	{
		PosibilityOfRemoving = false;

	}
	public void SetCommand(Command c)
	{
		command = c;

	}
  }
