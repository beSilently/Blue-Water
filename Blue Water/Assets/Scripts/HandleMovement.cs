using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleMovement : MonoBehaviour {

	private Rigidbody2D rb;
	private Vector2 mousePos;
	private Vector2 offset;
	private bool clicked;
    private GameObject wall_bottom;

	private void Start () {
		rb = GetComponent<Rigidbody2D> ();
		offset = transform.position;
        wall_bottom = GameObject.Find("Wall_bottom");
	}

    private void FixedUpdate () {
		if (Input.GetMouseButton (0)) {
			mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);

			if (!clicked) {
				offset = (Vector2) transform.position - mousePos + new Vector2 (0, Camera.main.GetComponent<CameraMovement> ().cameraSpeed);
				clicked = true;
            }

			Vector2 newPos = new Vector2 (
                Mathf.Clamp (mousePos.x + offset.x, Camera.main.GetComponent<CameraPosition>().leftEdge + 0.32f, Camera.main.GetComponent<CameraPosition>().rightEdge - 0.32f),
                mousePos.y + offset.y
            );

			rb.MovePosition (newPos);
		}
		else {
			rb.MovePosition (transform.position + new Vector3 (0, Camera.main.GetComponent<CameraMovement> ().cameraSpeed, 0));
            clicked = false;
		}
	}
    private float AdjustY(float pos) {
        if(pos < wall_bottom.transform.position.y) {
            return wall_bottom.transform.position.y;
        }
        return pos;
    }
}
