using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D playerRB;
    Animator thrustAnimation;
    AudioSource audioSource;
    [SerializeField] GameObject bulletPrefab;

    [SerializeField] float thrustForce;
    [SerializeField] float rotationSpeed;

    [SerializeField] float screenBoundaryX;
    [SerializeField] float screenBoundaryY;

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        thrustAnimation = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        transform.Rotate(0, 0, -Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.UpArrow))
        {
            playerRB.AddForce(transform.up * thrustForce);
            thrustAnimation.SetBool("isThrusting", true);
            if (!audioSource.isPlaying) // without this, the audio will layer over itself every frame, leading to distortion / noise
            {
                audioSource.Play();
            }
        }
        else
        {
            thrustAnimation.SetBool("isThrusting", false);
            audioSource.Stop();
        }

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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, transform.position, transform.rotation);
        }
    }
}