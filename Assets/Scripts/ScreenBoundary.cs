using UnityEngine;

public class ScreenBoundary : MonoBehaviour
{
    public static ScreenBoundary instance;

    // Config
    [SerializeField] float screenBoundaryX = 18.4f;
    [SerializeField] float screenBoundaryY = 10.5f;

    void Awake()
    {
        instance = this;
    }

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

    public Vector2 RangeForHyperspace()
    {
        float randomPosX;
        float randomPosY;
        randomPosX = Random.Range(screenBoundaryX, -screenBoundaryX);
        randomPosY = Random.Range(screenBoundaryY, -screenBoundaryY);
        return new Vector2(randomPosX, randomPosY);
    }
}
