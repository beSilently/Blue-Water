using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager1 : MonoBehaviour {


	public List<GameObject> objectsOfGarbage= new List<GameObject> ();
    List<GameObject> garbageOfParrot = new List<GameObject> (); 
	//public List<string> namesOfAllgarbageOfParrot;
	public Text scoretext;
	public int scores=0;

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
		GameObject paperPlane = (GameObject)Resources.Load ("PaperPlane");
		GameObject fork = (GameObject)Resources.Load ("MetalFork");
		GameObject leaf = (GameObject)Resources.Load ("Leaf");
	
		garbageOfParrot.Add (fork);
		garbageOfParrot.Add (leaf);
		//namesOfAllgarbageOfParrot.Add (paperPlane.name);
		//namesOfAllgarbageOfParrot.Add (fork.name);
		//namesOfAllgarbageOfParrot.Add (leaf.name);

		objectsOfGarbage.Add ((GameObject)Instantiate (banana, new Vector3 (-4.08f, -3.78f, 0), Quaternion.identity));
		objectsOfGarbage.Add ((GameObject)Instantiate (plasticBattle, new Vector3 (-3.0f, -3.68f, 0), Quaternion.identity));
		objectsOfGarbage.Add ((GameObject)Instantiate (preserveCan, new Vector3 (-1.29f, -3.75f, 0), Quaternion.identity));
		objectsOfGarbage.Add ((GameObject)Instantiate (battery, new Vector3 (0.16f, -3.9f, 0), Quaternion.identity));
		objectsOfGarbage.Add ((GameObject)Instantiate (saladBowl, new Vector3 (1.7f, -3.79f, 0), Quaternion.identity));
		objectsOfGarbage.Add ((GameObject)Instantiate (box, new Vector3 (3.55f, -3.88f, 0), Quaternion.identity));
		objectsOfGarbage.Add ((GameObject)Instantiate (paperPlane, new Vector3 (4.71f, 5.27f, 0), Quaternion.identity));
		//namesOfAllgarbageOfParrot.Add (objectsOfGarbage[objectsOfGarbage.Count-1].name);

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

		GameObject.FindGameObjectWithTag ("Parrot").GetComponent<FlyingOfParrot> ().flightUp += DisplayNewRubbishOfParrot;


   }
	public void FixedUpdate()
	{
		scoretext.text = scores.ToString ();
		if (objectsOfGarbage.Count == 0 && garbageOfParrot.Count == 0) 
		{   DontDestroyOnLoad(this.gameObject);
			SceneManager.LoadScene("ResultOfGame");
		}
	}

	public void DisplayNewRubbish(Vector3 position)
	{  
		for (int i=0; i<objectsOfGarbage.Count; i++) 
		{    
			if(objectsOfGarbage[i].GetComponent<Rubbish>() && objectsOfGarbage[i].GetComponent<Rubbish>().DisplayedOnScene==false)
			{   
				objectsOfGarbage[i]=((GameObject)Instantiate(objectsOfGarbage[i],position,Quaternion.identity));
				objectsOfGarbage[i].GetComponent<Rubbish>().Deleted+=DisplayNewRubbish;
				break;
			}
		}
	}  
	public void DisplayNewRubbishOfParrot(Vector3 position)
	{  
		if(garbageOfParrot.Count>0)
		{
			objectsOfGarbage.Add((GameObject)Instantiate(garbageOfParrot[0],position,Quaternion.identity));
			objectsOfGarbage[objectsOfGarbage.Count-1].GetComponent<ParrotsRubbish>().Deleted+=DisplayNewRubbish;
			//namesOfAllgarbageOfParrot.Add (objectsOfGarbage[objectsOfGarbage.Count-1].name);
			garbageOfParrot.RemoveAt(0);
		}	
			


	}  
}


