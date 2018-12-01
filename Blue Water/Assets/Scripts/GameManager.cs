using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	static public GameManager gm;
	
	public Transform GameplayUI;

	private void Awake () {
		gm = this;
		GameplayUI = transform.Find ("GameplayUI");
	}

}