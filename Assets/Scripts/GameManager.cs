using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // References
    public Text scoreText;

    // Config
    int score;
    [SerializeField] int bonus;
    [SerializeField] int bonusInterval;

    void Awake()
    {
        instance = this;
        bonus = bonusInterval;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Game");
        }

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