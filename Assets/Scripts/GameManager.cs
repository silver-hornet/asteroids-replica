using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // References
    public Text scoreText;
    [SerializeField] GameObject largeAsteroid;
    [SerializeField] Image life1;
    [SerializeField] Image life2;
    [SerializeField] Image life3;
    [SerializeField] Image life4;
    [SerializeField] Image life5;
    [SerializeField] Image life6;
    [SerializeField] Image life7;
    [SerializeField] Image life8;
    [SerializeField] Image life9;
    [SerializeField] Image life10;
    [SerializeField] Sprite life;
    [SerializeField] Sprite noLife;
    [SerializeField] GameObject titleScreen;
    [SerializeField] GameObject player1Screen;
    [SerializeField] GameObject player;
    int loadingTime = 3;
    bool isGameActive;
    [SerializeField] GameObject gameOverScreen;

    // Config
    int score;
    int bonus;
    [SerializeField] int bonusInterval = 10000;
    float asteroidSpawnPosXMin = 13f;
    float asteroidSpawnPosXMax = 18f;
    float asteroidSpawnPosYMin = -10f;
    float asteroidSpawnPosYMax = 10f;
    int asteroidCount;
    [SerializeField] int asteroidWaveNumber = 4;

    void Awake()
    {
        instance = this;
        bonus = bonusInterval;
    }

    void Start()
    {

        isGameActive = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            titleScreen.SetActive(false);
            player1Screen.SetActive(true);
            StartCoroutine(StartGameCo());
        }

        if (isGameActive == true)
        {
            asteroidCount = FindObjectsOfType<AsteroidController>().Length;

            if (asteroidCount == 0)
            {
                asteroidWaveNumber++;
                SpawnAsteroidWave(asteroidWaveNumber);
            }
        }
    }

    IEnumerator StartGameCo()
    {
        yield return new WaitForSeconds(loadingTime);
        player1Screen.SetActive(false);
        StartGame();
    }

    void StartGame()
    {
        isGameActive = true;
        player.SetActive(true);
        SpawnAsteroidWave(asteroidWaveNumber);
    }

    void SpawnAsteroidWave(int asteroidsToSpawn)
    {
        for (int i = 0; i < asteroidsToSpawn; i++)
        {
            Instantiate(largeAsteroid, GenerateAsteroidSpawnPosition(), largeAsteroid.transform.rotation);
        }
    }

    Vector2 GenerateAsteroidSpawnPosition()
    {
        float randomSignX = Mathf.Sign(Random.Range(-1, 1));
        float randomSignY = Mathf.Sign(Random.Range(-1, 1));
        float spawnPosX = randomSignX * Random.Range(asteroidSpawnPosXMin, asteroidSpawnPosXMax);
        float spawnPosY = randomSignY * Random.Range(asteroidSpawnPosYMin, asteroidSpawnPosYMax);
        Vector2 randomPos = new Vector2(spawnPosX, spawnPosY);
        return randomPos;
    }

    public void RespawnPlayer(Vector2 respawnPosition)
    {
        StartCoroutine(RespawnCo(respawnPosition));
    }

    IEnumerator RespawnCo(Vector2 respawnPosition)
    {
        PlayerController.instance.gameObject.SetActive(false);
        yield return new WaitForSeconds(2);
        PlayerController.instance.gameObject.SetActive(true);
        PlayerController.instance.transform.position = respawnPosition;
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = score.ToString();
        if (score >= bonus)
        {
            PlayerHealth.instance.ExtraLife();
            bonus += bonusInterval;
        }
    }

    public void UpdateNumberOfLives()
    {
        switch (PlayerHealth.instance.currentLives)
        {
            case 10:
                life1.sprite = life;
                life2.sprite = life;
                life3.sprite = life;
                life4.sprite = life;
                life5.sprite = life;
                life6.sprite = life;
                life7.sprite = life;
                life8.sprite = life;
                life9.sprite = life;
                life10.sprite = life;
                break;

            case 9:
                life1.sprite = life;
                life2.sprite = life;
                life3.sprite = life;
                life4.sprite = life;
                life5.sprite = life;
                life6.sprite = life;
                life7.sprite = life;
                life8.sprite = life;
                life9.sprite = life;
                life10.sprite = noLife;
                break;

            case 8:
                life1.sprite = life;
                life2.sprite = life;
                life3.sprite = life;
                life4.sprite = life;
                life5.sprite = life;
                life6.sprite = life;
                life7.sprite = life;
                life8.sprite = life;
                life9.sprite = noLife;
                life10.sprite = noLife;
                break;

            case 7:
                life1.sprite = life;
                life2.sprite = life;
                life3.sprite = life;
                life4.sprite = life;
                life5.sprite = life;
                life6.sprite = life;
                life7.sprite = life;
                life8.sprite = noLife;
                life9.sprite = noLife;
                life10.sprite = noLife;
                break;

            case 6:
                life1.sprite = life;
                life2.sprite = life;
                life3.sprite = life;
                life4.sprite = life;
                life5.sprite = life;
                life6.sprite = life;
                life7.sprite = noLife;
                life8.sprite = noLife;
                life9.sprite = noLife;
                life10.sprite = noLife;
                break;

            case 5:
                life1.sprite = life;
                life2.sprite = life;
                life3.sprite = life;
                life4.sprite = life;
                life5.sprite = life;
                life6.sprite = noLife;
                life7.sprite = noLife;
                life8.sprite = noLife;
                life9.sprite = noLife;
                life10.sprite = noLife;
                break;

            case 4:
                life1.sprite = life;
                life2.sprite = life;
                life3.sprite = life;
                life4.sprite = life;
                life5.sprite = noLife;
                life6.sprite = noLife;
                life7.sprite = noLife;
                life8.sprite = noLife;
                life9.sprite = noLife;
                life10.sprite = noLife;
                break;

            case 3:
                life1.sprite = life;
                life2.sprite = life;
                life3.sprite = life;
                life4.sprite = noLife;
                life5.sprite = noLife;
                life6.sprite = noLife;
                life7.sprite = noLife;
                life8.sprite = noLife;
                life9.sprite = noLife;
                life10.sprite = noLife;
                break;

            case 2:
                life1.sprite = life;
                life2.sprite = life;
                life3.sprite = noLife;
                life4.sprite = noLife;
                life5.sprite = noLife;
                life6.sprite = noLife;
                life7.sprite = noLife;
                life8.sprite = noLife;
                life9.sprite = noLife;
                life10.sprite = noLife;
                break;

            case 1:
                life1.sprite = life;
                life2.sprite = noLife;
                life3.sprite = noLife;
                life4.sprite = noLife;
                life5.sprite = noLife;
                life6.sprite = noLife;
                life7.sprite = noLife;
                life8.sprite = noLife;
                life9.sprite = noLife;
                life10.sprite = noLife;
                break;

            case 0:
                life1.sprite = noLife;
                life2.sprite = noLife;
                life3.sprite = noLife;
                life4.sprite = noLife;
                life5.sprite = noLife;
                life6.sprite = noLife;
                life7.sprite = noLife;
                life8.sprite = noLife;
                life9.sprite = noLife;
                life10.sprite = noLife;
                break;
        }
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        StartCoroutine(GameOverCo());
    }

    IEnumerator GameOverCo()
    {
        yield return new WaitForSeconds(loadingTime);
        isGameActive = false;
        gameOverScreen.SetActive(false);
        titleScreen.SetActive(true);
    }
}