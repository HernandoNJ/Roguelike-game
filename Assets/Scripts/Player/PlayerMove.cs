using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
public class PlayerMove: MonoBehaviour
{
    // Assign a PlayerInput component in the inspector
    // Assign these references in the inspector
    [SerializeField] private InputActionReference movementInput, jumpButtonInput;
    [SerializeField] private Vector2 moveInputValue;
    [SerializeField] private float speed;

    private void OnEnable()
    {
        jumpButtonInput.action.performed += HandleJump;
    }
    
    private void Update()
    {
        moveInputValue = movementInput.action.ReadValue<Vector2>();
        moveInputValue.Normalize();
        HandleMovement(moveInputValue);
        
        // ApplyGravity();
        // UpdateJumpState();
    }
    
    private void HandleJump(InputAction.CallbackContext obj)
    {
        // jump logic
    }

    private void HandleMovement(Vector2 moveInputArg)
    {
        // Apply the movement to the player's position
        transform.Translate(moveInputArg * (speed * Time.deltaTime));  
    }
    
    private void HandleMovement2(InputAction.CallbackContext ctx)
    {
        moveInputValue = movementInput.action.ReadValue<Vector2>();
        moveInputValue.Normalize();
    }


    private void OnDisable()
    {
        movementInput.action.performed -= HandleMovement2;
        jumpButtonInput.action.performed -= HandleJump;
    }
}
}