using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private GameObject gameoverCanvas;
    [SerializeField] private GameObject startCanvas;
    [SerializeField] private GameObject player;
     
    [SerializeField] private AudioClip flySound;
    [SerializeField] private AudioClip coinSound;
    [SerializeField] private AudioClip gameOverSound;

    private AudioSource audioSource;

    private enum GameState
    {
        StartScreen,
        Playing,
        GameOver
    }

    private GameState currentState;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        audioSource = GetComponent<AudioSource>();
        SetState(GameState.StartScreen);
    }

    void Update()
    {
        if (currentState == GameState.StartScreen && Input.GetMouseButtonDown(0))
        {
            SetState(GameState.Playing);
        }
        // Optional: You can add a condition to restart the game from the GameOver state
        // if (currentState == GameState.GameOver && Input.GetMouseButtonDown(0))
        // {
        //     RestartGame();
        // }
    }

    private void SetState(GameState newState)
    {
        currentState = newState;

        switch (currentState)
        {
            case GameState.StartScreen:
                startCanvas.SetActive(true);
                gameoverCanvas.SetActive(false);
                Time.timeScale = 0f;
                break;
            case GameState.Playing:
                startCanvas.SetActive(false);
                gameoverCanvas.SetActive(false);
                player.SetActive(true);
                Time.timeScale = 1f;
                break;
            case GameState.GameOver:
                startCanvas.SetActive(false);
                gameoverCanvas.SetActive(true);
                Time.timeScale = 0f;
                break;
        }
    }

    public void PlayFlySound()
    {
        audioSource.PlayOneShot(flySound);
    }

    public void PlayCoinSound()
    {
        audioSource.PlayOneShot(coinSound);
    }


    public void GameOver()
    {
        SetState(GameState.GameOver);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
