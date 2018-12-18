using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
	public Text result;
	public Text description;

	void Start ()
	{ int Scores = GameObject.FindGameObjectWithTag ("Manager").GetComponent<GameManager> ().scores;
	  
		if (Scores >= 1700)
		{ description.text  = "Thank you very much! You did a great job!";

		} 
		else if (Scores >= 1500) 
		{
			description.text = "Thank you! You did a good job!";

		} else if (Scores >= 1000)
		{
			description.text = "You should be a little more attentive.";

		} else 
		{
			description.text = "You should be careful! This sorting is important!";
		}
		result.text = "Your scores: " + Scores.ToString();
	}
	


}

