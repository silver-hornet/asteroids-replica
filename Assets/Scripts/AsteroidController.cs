using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    // References
    Rigidbody2D asteroidRB;
    [SerializeField] GameObject nextAsteroid;
    [SerializeField] AudioClip explosionSFX;
    [SerializeField] GameObject explosionVFX;

    // Config
    float moveSpeedX;
    float moveSpeedY;
    [SerializeField] float minSpeed;
    [SerializeField] float maxSpeed;
    [SerializeField] int pointValue;

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

    void OnCollisionEnter2D(Collision2D other)
    {
        AudioSource.PlayClipAtPoint(explosionSFX, transform.position, 1f);
        // TODO Refactor this out into an audio manager script. Not using Play or PlayOneShot because they immediately get destroyed along with the game object.

        if (nextAsteroid != null)
        {
            Instantiate(nextAsteroid, asteroidRB.position, Quaternion.identity);
            Instantiate(nextAsteroid, asteroidRB.position, Quaternion.identity);
        }

        if (other.gameObject.tag == "Bullet")
        {
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Player")
        {
            PlayerHealth.instance.KillPlayer();
        }

        GameManager.instance.UpdateScore(pointValue);
        GameObject tempExplosion = Instantiate(explosionVFX, transform.position, transform.rotation);
        Destroy(tempExplosion, 2f);
        Destroy(gameObject);
    }
}