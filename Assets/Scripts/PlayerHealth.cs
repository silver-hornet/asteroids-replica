using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;

    // Config
    public int currentLives;
    [SerializeField] int maxLives;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentLives = maxLives;
        GameManager.instance.UpdateNumberOfLives();
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

        GameManager.instance.UpdateNumberOfLives();
    }

    public void ExtraLife()
    {
        currentLives += 1;
        GameManager.instance.UpdateNumberOfLives();
    }
}