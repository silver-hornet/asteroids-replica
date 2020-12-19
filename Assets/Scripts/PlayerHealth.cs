using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;

    // References
    // [SerializeField] GameObject deathEffect;

    // Config
    [SerializeField] int currentLives;
    [SerializeField] int maxLives;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentLives = maxLives;
    }

    public void KillPlayer()
    {

        currentLives--;

        if (currentLives > 0)
        {
            // Instantiate(deathEffect, transform.position, transform.rotation);
            GameManager.instance.RespawnPlayer(new Vector2(0, 0));
        }
        else if (currentLives <= 0)
        {
            currentLives = 0;
            Destroy(gameObject);
        }
    }

    public void ExtraLife()
    {
        currentLives += 1;
    }
}