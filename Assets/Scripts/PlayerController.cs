using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // References
    Rigidbody2D playerRB;
    Animator thrustAnimation;
    AudioSource audioSource;
    [SerializeField] GameObject bulletPrefab;

    // Config
    [SerializeField] float thrustForce;
    [SerializeField] float rotationSpeed;

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        thrustAnimation = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        ApplyRotation();
        ApplyThrust();
        FireBullet();
    }

    void ApplyRotation()
    {
        transform.Rotate(0, 0, -Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime);
    }

    void ApplyThrust()
    {
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
    }

    void FireBullet()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, transform.position, transform.rotation);
        }
    }
}