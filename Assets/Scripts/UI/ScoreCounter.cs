using UnityEngine;

public class ScoreCounter: MonoBehaviour
{
    private static int score;
    public static int Score { 
        get => score; 
        set 
        {
            if (value < score)
            {
                return;
            }
            else
            {
                score = value;
            }
        } 
    }
    private int beginY;

    private void Start()
    {
        beginY = (int)transform.position.y;
        score = beginY;
    }

    private void Update()
    {
        Score = (int)transform.position.y - beginY;
    }
}
