using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private RacketMovement movement;
    [SerializeField] private KeyCode upButton, downButton;

    private void FixedUpdate()
    {
        if (Input.GetKey(upButton))
        {
            movement.MoveUp();
        }
        else if (Input.GetKey(downButton))
        {
            movement.MoveDown();
        }
        else
        {
            movement.Stay();
        }
        movement.UpdateBoundary();
    }
}
