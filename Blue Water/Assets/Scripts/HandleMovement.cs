using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class HandleMovement : MonoBehaviour
{

    public GameObject player;

    bool dragging = false;
    Vector3 mouseStartPos;      
    Vector3 playerStartPos;
    float leftEdge;
    float rightEdge;

    private void Start()
    {
        leftEdge = Camera.main.GetComponent<CameraPosition>().leftEdge;
        rightEdge = Camera.main.GetComponent<CameraPosition>().rightEdge;
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragging = true;
            mouseStartPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
            playerStartPos = player.transform.position;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            dragging = false;
        }
        else 
        {
            player.transform.position += new Vector3(0, Camera.main.GetComponent<CameraMovement>().cameraSpeed, 0);
        }

        if (dragging)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
            Vector3 newPlayerPositiion = playerStartPos + mousePos - mouseStartPos;
            AdjustX(ref newPlayerPositiion.x);
            player.transform.position = newPlayerPositiion;
        }
    }
    void AdjustX(ref float pos)
    {
        float radiusOfHandleObject = this.GetComponent<CircleCollider2D>().radius;
        if (pos < leftEdge)
        {
            pos = leftEdge;
        }
        else if (pos > rightEdge)
        {
            pos = rightEdge;
        }
    }
}
