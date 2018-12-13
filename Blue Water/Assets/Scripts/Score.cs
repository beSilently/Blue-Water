using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text scoreText;
    public Transform target;
    int score;

	void Update () {
        score = Mathf.RoundToInt(2 * (target.transform.position.y + 3));
        scoreText.text = score.ToString();

        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
}
