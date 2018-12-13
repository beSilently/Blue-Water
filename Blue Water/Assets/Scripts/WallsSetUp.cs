using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsSetUp : MonoBehaviour {

	public BoxCollider2D Wall_right;
    public BoxCollider2D Wall_bottom;
    public BoxCollider2D Wall_left;


    private void Start () {

        CameraPosition camPos = Camera.main.GetComponent<CameraPosition>();

		Wall_right.size = new Vector2 (1, Camera.main.orthographicSize * 4);
		Wall_bottom.size = new Vector2 (Camera.main.orthographicSize * Camera.main.aspect * 2 + 2, 1);
		Wall_left.size = new Vector2 (1, Camera.main.orthographicSize * 4);

        Wall_right.offset = new Vector2(camPos.rightEdge + 0.5f, camPos.bottomEdge);
        Wall_bottom.offset = new Vector2(0, camPos.bottomEdge - Wall_bottom.size.y * 1/2);
        Wall_left.offset = new Vector2(camPos.leftEdge - 0.5f, camPos.bottomEdge);
    }

}