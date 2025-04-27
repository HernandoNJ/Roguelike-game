using UnityEngine;
using UnityEngine.InputSystem;

namespace z_Old.Player
{
public class PlayerMovement3 : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f; 

    private Vector2 movementInput; 

    // Called by the Player Input component when the Move action is triggered
    private void OnMove(InputValue value)
    {
        // Get the input value as a Vector2
        movementInput = value.Get<Vector2>();
        movementInput.Normalize();
    }

    private void Update()
    {
        MovePlayer();
    }

    // Move the player based on the input
    private void MovePlayer()
    {
        // Calculate the movement vector
        var movement = movementInput * (moveSpeed * Time.deltaTime);

        // Apply the movement to the player's position
        transform.Translate(movement);
    }
}
}
