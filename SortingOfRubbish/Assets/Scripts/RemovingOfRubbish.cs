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

public class RemovingOfParrotsRubbish : Command
{
	public ParrotsRubbish rub;
	public RemovingOfParrotsRubbish(ParrotsRubbish garbage)
	{
		rub = garbage;
	}
	public override void Execute ()
	{  
		rub.Remove1();
	}
	public override void Undo ()
	{  
		rub.ReturnInitialPosition ();
	}
	
}

