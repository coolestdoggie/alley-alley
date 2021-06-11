using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] ScreenManager screenManager;
    int score = 0;

    private void OnEnable()
    {
        PlayerController.GameOver += GameOver;
    }

    private void OnDisable()
    {
        PlayerController.GameOver -= GameOver;
    }

    private void Start()
    {
        screenManager.StartScreen.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            screenManager.StartScreen.SetActive(false);
        }
    }

    private void AddToScore(int scoreValue)
    {
        score += scoreValue;
    }

    public int Score { get => score; set => score = value; }

    private void GameOver()
    {
        screenManager.GameOverScreen.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
