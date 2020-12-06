using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBoundary : MonoBehaviour
{
    // Config
    [SerializeField] float screenBoundaryX = 18.4f;
    [SerializeField] float screenBoundaryY = 10.5f;

    void Update()
    {
        CheckScreenBoundaries();
    }

    void CheckScreenBoundaries()
    {
        if (transform.position.x > screenBoundaryX)
        {
            transform.position = new Vector2(-screenBoundaryX, transform.position.y);
        }
        else if (transform.position.x < -screenBoundaryX)
        {
            transform.position = new Vector2(screenBoundaryX, transform.position.y);
        }
        else if (transform.position.y > screenBoundaryY)
        {
            transform.position = new Vector2(transform.position.x, -screenBoundaryY);
        }
        else if (transform.position.y < -screenBoundaryY)
        {
            transform.position = new Vector2(transform.position.x, screenBoundaryY);
        }
    }
}
