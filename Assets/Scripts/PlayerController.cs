using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    // References
    Rigidbody2D playerRB;
    Animator thrustAnimation;
    AudioSource audioSource;
    [SerializeField] GameObject bulletPrefab;

    // Config
    [SerializeField] float thrustForce;
    [SerializeField] float rotationSpeed;

    void Awake()
    {
        instance = this;
    }

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
        Hyperspace();
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
            if (!audioSource.isPlaying) // Without this, the audio will layer over itself every frame, leading to distortion / noise
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

    void Hyperspace()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            GameManager.instance.RespawnPlayer(ScreenBoundary.instance.RangeForHyperspace());
        }
    }
}