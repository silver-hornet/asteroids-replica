using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;
    [SerializeField] int currentHealth, maxHealth;
    // [SerializeField] GameObject deathEffect;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void KillPlayer()
    {

        currentHealth--;

        if (currentHealth > 0)
        {
            // Instantiate(deathEffect, transform.position, transform.rotation);
            GameManager.instance.RespawnPlayer(new Vector2(0, 0));
        }
        else if (currentHealth <= 0)
        {
            currentHealth = 0;
            Destroy(gameObject);
        }
    }
}