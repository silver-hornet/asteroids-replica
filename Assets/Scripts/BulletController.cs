using UnityEngine;

public class BulletController : MonoBehaviour
{
    // References
    Rigidbody2D bulletRB;
    AudioSource audioSource;
    [SerializeField] AudioClip bulletAudio;

    // Config
    [SerializeField] float bulletSpeed;
    [SerializeField] float destroyBulletDelay;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        bulletRB = GetComponent<Rigidbody2D>();
        FireBullet();
    }

    void FireBullet()
    {
        bulletRB.AddForce(transform.up * bulletSpeed);
        audioSource.PlayOneShot(bulletAudio);
        Destroy(gameObject, destroyBulletDelay);
    }
}