using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {


	public List<GameObject> objectsOfGarbage= new List<GameObject> ();

	public void Start ()
	{

		GameObject banana = (GameObject)Resources.Load ("Banana");
		GameObject plasticBattle = (GameObject)Resources.Load ("PlasticBattle");
		GameObject glassPot = (GameObject)Resources.Load ("GlassPot");
		GameObject preserveCan = (GameObject)Resources.Load ("PreserveCan");
		GameObject battery = (GameObject)Resources.Load ("Battery");
		GameObject book = (GameObject)Resources.Load ("Book");
		GameObject box = (GameObject)Resources.Load ("Box");
		GameObject bulb = (GameObject)Resources.Load ("Bulb");
		GameObject fish = (GameObject)Resources.Load ("Fish");
		GameObject glassBattle = (GameObject)Resources.Load ("GlassBattle");
		GameObject hairDryer = (GameObject)Resources.Load ("HairDryer");
		GameObject pinkPlasticContainer = (GameObject)Resources.Load ("PinkPlasticContainer");
		GameObject saladBowl = (GameObject)Resources.Load ("SaladBowl");
		GameObject scissors = (GameObject)Resources.Load ("Scissors");
		GameObject shampoo = (GameObject)Resources.Load ("Shampoo");

		objectsOfGarbage.Add ((GameObject)Instantiate (banana, new Vector3 (-4.08f, -3.78f, 0), Quaternion.identity));
		objectsOfGarbage.Add ((GameObject)Instantiate (plasticBattle, new Vector3 (-3.0f, -3.68f, 0), Quaternion.identity));
		objectsOfGarbage.Add ((GameObject)Instantiate (preserveCan, new Vector3 (-1.29f, -3.75f, 0), Quaternion.identity));
		objectsOfGarbage.Add ((GameObject)Instantiate (battery, new Vector3 (0.16f, -3.9f, 0), Quaternion.identity));
		objectsOfGarbage.Add ((GameObject)Instantiate (saladBowl, new Vector3 (1.7f, -3.79f, 0), Quaternion.identity));
		objectsOfGarbage.Add ((GameObject)Instantiate (box, new Vector3 (3.55f, -3.88f, 0), Quaternion.identity));

		foreach (GameObject rub in objectsOfGarbage)
		{
			rub.GetComponent<Rubbish>().Deleted+=DisplayNewRubbish;
			
		}

		objectsOfGarbage.Add (glassPot);
		objectsOfGarbage.Add (book);
		objectsOfGarbage.Add (bulb);
		objectsOfGarbage.Add (fish);
		objectsOfGarbage.Add (glassBattle);
		objectsOfGarbage.Add (hairDryer);
		objectsOfGarbage.Add (pinkPlasticContainer);
		objectsOfGarbage.Add (scissors);
		objectsOfGarbage.Add (shampoo);

   }

	public void DisplayNewRubbish(Vector3 position)
	{  
		for (int i=0; i<objectsOfGarbage.Count; i++) 
		{    
			if(objectsOfGarbage[i].GetComponent<Rubbish>().DisplayedOnScene==false)
			{   
				objectsOfGarbage[i]=((GameObject)Instantiate(objectsOfGarbage[i],position,Quaternion.identity));
				objectsOfGarbage[i].GetComponent<Rubbish>().Deleted+=DisplayNewRubbish;
				break;
			}
		}
	}    
}


