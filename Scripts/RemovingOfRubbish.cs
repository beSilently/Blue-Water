using UnityEngine;
using System.Collections;

public class RemovingOfRubbish : Command
{
	public Rubbish rub;
	public RemovingOfRubbish(Rubbish garbage)
	{
		rub = garbage;
	}
	public override void Execute ()
	{  
		rub.Remove ();
	}
	public override void Undo ()
	{  
		rub.ReturnInitialPosition ();
	}

}

