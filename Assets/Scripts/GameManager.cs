using System;
using UnityEngine;

[Serializable]
public enum Side
{
    Left,
    Right
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Action<Side> OnGameOver;
    public Action OnGameStarted;
    [SerializeField] private ScoreController scoreController;
    [SerializeField] private GameObject ball;
    [SerializeField] private float ballSpeed;
    [SerializeField] private int maxScore;
    [SerializeField] private float timeToNextGame = 2;
    [SerializeField] private Transform[] rackets;

    private GameObject currentBall;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        scoreController.OnScoreTaken += (side, score) =>
        {
            Destroy(currentBall);
            if (score >= maxScore)
            {
                GameOver(side);
            }
            else
            {
                Invoke("SpawnBall", timeToNextGame);
            }
        };
    }

    private void GameOver(Side winPlayer)
    {
        if (OnGameOver != null)
        {
            OnGameOver(winPlayer);
        }
    }

    private void SpawnBall()
    {
        currentBall = Instantiate(ball, Vector3.zero, Quaternion.identity);
        Rigidbody2D rg = currentBall.GetComponent<Rigidbody2D>();
        if (rg)
        {
            Vector2 randomForce = new Vector2(UnityEngine.Random.Range(0, 2) == 0 ? ballSpeed : -ballSpeed, UnityEngine.Random.Range(0, 2) == 0 ? ballSpeed : -ballSpeed);
            rg.AddForce(randomForce);
        }
    }

    public void StartGame()
    {
        foreach (Transform racket in rackets)
        {
            racket.position = new Vector2(racket.position.x, 0);
        }

        if (OnGameStarted != null)
        {
            OnGameStarted();
        }
        Invoke("SpawnBall", timeToNextGame);
    }
}
