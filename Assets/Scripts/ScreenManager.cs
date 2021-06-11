using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    [SerializeField] GameObject startScreen;
    [SerializeField] GameObject gameOverScreen;

    public GameObject StartScreen { get => startScreen; set => startScreen = value; }
    public GameObject GameOverScreen { get => gameOverScreen; set => gameOverScreen = value; }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
