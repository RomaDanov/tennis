using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] ScoreController sc;
    [SerializeField] private Text leftScore, rightScore, winText;
    [SerializeField] private GameObject gameOverWindow;
    [SerializeField] private GameObject startMenuWindow;

    private void Start()
    {
        if (GameManager.instance)
        {
            GameManager.instance.OnGameOver += OpenGameOverWindow;
            GameManager.instance.OnGameStarted += () =>
            {
                startMenuWindow.SetActive(false);
                gameOverWindow.SetActive(false);
                ResetScore();
            };
        }

        if (sc)
        {
            sc.OnScoreTaken += UpdateScore;
        }
    }

    private void OpenGameOverWindow(Side side)
    {
        gameOverWindow.SetActive(true);
        switch (side)
        {
            case Side.Left:
                winText.text = "Player 1 WIN!";
                break;
            case Side.Right:
                winText.text = "Player 2 WIN!";
                break;
        }
    }

    private void UpdateScore(Side side, int score)
    {
        switch (side)
        {
            case Side.Left:
                leftScore.text = score.ToString();
                break;
            case Side.Right:
                rightScore.text = score.ToString();
                break;
        }
    }

    private void ResetScore()
    {
        rightScore.text = "0";
        leftScore.text = "0";
    }

    public void OnStartGameClick()
    {
        GameManager.instance.StartGame();
    }
}
