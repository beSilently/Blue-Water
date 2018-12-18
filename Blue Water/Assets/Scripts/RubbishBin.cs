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
	public void  OnTriggerEnter2D(Collider2D col)
	{ 
		if (TypeOfRubbish == col.gameObject.GetComponent<Rubbish> ().TypeOfRubbish) 
		{

			PosibilityOfRemoving=true;
		} 


		if (col.gameObject.GetComponent<ParrotsRubbish>()!=null) 
		{ 
			//Debug.Log (col.gameObject.name);
			SetCommand (new RemovingOfParrotsRubbish (col.gameObject.GetComponent<ParrotsRubbish>()));
		} 
		else if(col.gameObject.GetComponent<Rubbish>()!=null)
		{  
			SetCommand (new RemovingOfRubbish (col.gameObject.GetComponent<Rubbish>()));
			//Debug.Log (col.gameObject.name);
		}

	}

	public void OnTriggerExit2D(Collider2D col)
	{
		PosibilityOfRemoving = false;
		command = null;

	}
	public void SetCommand(Command c)
	{
		command = c;

	}
  }
