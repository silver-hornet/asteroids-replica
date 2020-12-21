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
        SpawnAsteroidWave(asteroidWaveNumber);
    }

    void Update()
    {
        asteroidCount = FindObjectsOfType<AsteroidController>().Length;

        if (asteroidCount == 0)
        {
            asteroidWaveNumber++;
            SpawnAsteroidWave(asteroidWaveNumber);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Game");
        }
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
}