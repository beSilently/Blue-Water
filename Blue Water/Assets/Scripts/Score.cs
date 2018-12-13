using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text scoreText;
    public Transform target;

	void Update () {
        scoreText.text = (2 * (target.transform.position.y + 3)).ToString("0");
    }
}
