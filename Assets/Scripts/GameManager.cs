using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int score = 0;

    public void AddToScore(int scoreValue)
    {
        score += scoreValue;
    }

    public int Score { get => score; set => score = value; }


    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
