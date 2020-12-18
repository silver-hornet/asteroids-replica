using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    void Awake()
    {
        instance = this;
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
}