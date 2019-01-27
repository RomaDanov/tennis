using UnityEngine;

[System.Serializable]
public struct Boundary
{
    public float minY;
    public float maxY;
}

public class RacketMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private Boundary boundary;
    [SerializeField] private float speed = 150;

    public void MoveUp()
    {
        rb2d.velocity = new Vector2(0, Time.fixedDeltaTime * speed);
    }

    public void MoveDown()
    {
        rb2d.velocity = new Vector2(0, Time.fixedDeltaTime * -speed);
    }

    public void Stay()
    {
        rb2d.velocity = Vector2.zero;
    }

    public void UpdateBoundary()
    {
        rb2d.position = new Vector2(rb2d.position.x, Mathf.Clamp(rb2d.position.y, boundary.minY, boundary.maxY));
    }
}
