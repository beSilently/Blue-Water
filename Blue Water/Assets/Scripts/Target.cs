using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Target : MonoBehaviour {

    private Text LevelText;
    int currentLevelNumber;

    private void Start () {
        LevelText = GameManager.gm.GameplayUI.Find("LevelPlaceholder").Find("Level").GetComponent<Text>();
        currentLevelNumber = 1;
        LevelText.text = currentLevelNumber.ToString() + "/99";
    }
	
	private void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Obstacle") {
			print ("GAME OVER!");
			SceneManager.LoadScene ("Gameplay");
		}
		else if (other.tag == "LevelEnd") {
			other.tag = "Untagged"; //Can trigger only once (needs, bcz balloon has 2 colliders)
            currentLevelNumber++;
            LevelText.text = currentLevelNumber.ToString() + "/99";
        }
    }

}