using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	static public GameManager gm;
	
	public LevelsManager lm;
	public Transform GameplayUI;

	private void Awake () {
		gm = this;
		lm = GetComponent<LevelsManager> ();
		GameplayUI = transform.Find ("GameplayUI");
	}

}