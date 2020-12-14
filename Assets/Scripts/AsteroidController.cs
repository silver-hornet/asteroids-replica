using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    // References
    Rigidbody2D asteroidRB;

    // Config
    float moveSpeedX;
    float moveSpeedY;
    [SerializeField] float minSpeed;
    [SerializeField] float maxSpeed;

    void Start()
    {
        asteroidRB = GetComponent<Rigidbody2D>();
        moveSpeedX = Random.Range(minSpeed, maxSpeed) * Mathf.Sign(Random.Range(-1f, 1f));
        moveSpeedY = Random.Range(minSpeed, maxSpeed) * Mathf.Sign(Random.Range(-1f, 1f));
    }

    void Update()
    {
        
        asteroidRB.velocity = new Vector3(moveSpeedX, moveSpeedY, 0); // Use velocity, instead of something like AddForce, to ensure the same, constant speed
    }
}