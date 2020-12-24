using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;

    // References
    [SerializeField] GameObject player;

    // Config
    public int currentLives;
    public int maxLives;

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
            player.SetActive(false);
            GameManager.instance.GameOver();
        }

        GameManager.instance.UpdateNumberOfLives();
    }

    public void ExtraLife()
    {
        currentLives += 1;
        GameManager.instance.UpdateNumberOfLives();
    }
}