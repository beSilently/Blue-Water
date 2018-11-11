using UnityEngine;
using System.Collections;

public class SimpleAnimation : MonoBehaviour
{
	public Sprite [] Spriteframes;
	private int indexOfFrame;
	public GameObject anObject;
	public float TimeTimer;


	public SimpleAnimation()
	{
		Spriteframes = new Sprite[12];
		indexOfFrame = 0;
		TimeTimer = 0.2f;
	}


	void Update ()
	{    
		TimeTimer -= Time.deltaTime;
		if (TimeTimer <= 0)
		{
			ChangeTheFrame ();
			TimeTimer = 0.2f;
		}

	   
	}
	void ChangeTheFrame ()
	{
		if (indexOfFrame< Spriteframes.Length-1)
		{
			indexOfFrame++;
			
		} 
		else 
		{
			indexOfFrame=0;
		}
		anObject.GetComponent<SpriteRenderer>().sprite=Spriteframes[indexOfFrame];
		
	}

}

