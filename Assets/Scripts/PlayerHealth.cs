using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;

    // Config
    int currentLives;
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