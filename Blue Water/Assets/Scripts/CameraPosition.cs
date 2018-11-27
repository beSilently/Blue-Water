using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour {

    // set the desired aspect ratio 
    public float targetAspect = 16.0f / 9.0f;
    public float leftEdge { get; private set; }
    public float rightEdge { get; private set; }

    // Use this for initialization
    void Start()
    {
        // determine the game window's current aspect ratio
        float windowAspect = (float)Screen.width / (float)Screen.height;

        // current viewport height should be scaled by this amount
        float scaleHeight = windowAspect / targetAspect;

        // obtain camera component so we can modify its viewport
        Camera camera = GetComponent<Camera>();

        // if scaled height is less than current height, add letterbox
        if (scaleHeight < 1.0f)
        {
            Rect rect = new Rect
            {
                width = 1.0f,
                height = scaleHeight,
                x = 0,
                y = (1.0f - scaleHeight) / 2.0f
            };

            camera.rect = rect;
        }
        else // add pillarbox
        {
            float scaleWidth = 1.0f / scaleHeight;

            Rect rect = new Rect
            {
                width = scaleWidth,
                height = 1.0f,
                x = (1.0f - scaleWidth) / 2.0f,
                y = 0
            };

            camera.rect = rect;
        }
        leftEdge = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        rightEdge = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;

    }
}
