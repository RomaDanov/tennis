using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    [SerializeField] private ScoreController controller;
    [SerializeField] private Side side;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Ball"))
        {
            if (controller)
            {
                controller.BallHit(side);
            }
        }
    }
}
