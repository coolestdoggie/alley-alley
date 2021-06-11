using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameScreen : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;

    private void Update()
    {
        scoreText.text = ScoreCounter.Score.ToString();
    }
}
