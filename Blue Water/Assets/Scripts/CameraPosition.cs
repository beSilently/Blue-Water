using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour {

    // set the desired aspect ratio 
    public float targetAspect = 2.0f / 3.0f;

    public float leftEdge { get; private set; }
    public float rightEdge { get; private set; }
    public float bottomEdge { get; private set; }
    public float topEdge { get; private set; }

    void Start()     {         SetSize();     }

    private void Update()
    {
        SetSize();
    }

    private void SetSize()     {         Camera camera = GetComponent<Camera>();         float newWidthInPixels = (float)Screen.height * targetAspect;         float scaleWidth = newWidthInPixels / (float)Screen.width;          Rect rect = new Rect         {             width = scaleWidth,             height = 1.0f,             x = (1.0f - scaleWidth) / 2.0f,             y = 0         };         camera.rect = rect;          leftEdge = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;         rightEdge = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;         bottomEdge = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;         topEdge = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;     }
}
