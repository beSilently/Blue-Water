using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Balloon : MonoBehaviour {

	private Text ScoreText;
    private Text LevelText;
    int currentLevelNumber;

    private void Start () {
		ScoreText = GameManager.gm.GameplayUI.Find ("ScorePlaceholder").Find ("Score").GetComponent<Text> ();
        LevelText = GameManager.gm.GameplayUI.Find("LevelPlaceholder").Find("Level").GetComponent<Text>();
        currentLevelNumber = 1;
        LevelText.text = currentLevelNumber.ToString() + "/99";
    }
	
	private void Update () {
		ScoreText.text = Mathf.Max (0, Mathf.FloorToInt (transform.position.y)).ToString ();
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