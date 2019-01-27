using System;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public Action<Side, int> OnScoreTaken;
    private int player1score, player2score;

    private void Start()
    {
        GameManager.instance.OnGameStarted += ResetScore;
    }

    public void ResetScore()
    {
        player1score = 0;
        player2score = 0;
    }

    public void BallHit(Side side)
    {
        switch (side)
        {
            case Side.Left:
                player2score++;
                if (OnScoreTaken != null)
                {
                    OnScoreTaken(Side.Right, player2score);
                }
                break;
            case Side.Right:
                player1score++;
                if (OnScoreTaken != null)
                {
                    OnScoreTaken(Side.Left, player1score);
                }
                break;
        }
    }
}
