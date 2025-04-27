using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace z_Old.Player
{
public class PlayerMovement2 : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private bool facingRight;

    public UnityEvent<bool> onPlayerFlipped;

    private Camera mainCamera;
    private Vector2 screenBounds;
    private float playerWidth;
    private float playerHeight;

    private Rigidbody2D rb;
    private Vector2 movement;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        ConfigMainCamera();
        ConfigPlayerCollider();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void ConfigPlayerCollider()
    {
        // Get the player collider 2D component and calculate the size
        var playerCollider = GetComponent<CapsuleCollider2D>();
        playerWidth = playerCollider.bounds.extents.x * 2;
        playerHeight = playerCollider.bounds.extents.y * 2;
    }

    private void ConfigMainCamera()
    {
        mainCamera = Camera.main;
        if (mainCamera != null)
        {
            screenBounds =
                mainCamera.ScreenToWorldPoint(new Vector3(
                    Screen.width, Screen.height, mainCamera.transform.position.z));
        }
    }

    public void PlayerLook(InputAction.CallbackContext context)
    {
        Debug.Log($"{context.action} performed");
        Debug.Log("Player is looking");
    }

    public void PlayerFire(InputAction.CallbackContext context)
    {
        Debug.Log($"{context.action} performed");
        Debug.Log("Player is firing");
    }

    public void PlayerMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
        CheckMoveFacing();
    }
    
    private void MovePlayer()
    {
        rb.linearVelocity = movement * moveSpeed;

        // Constrain the player within the screen bounds
        var position = rb.position;
        position.x = Mathf.Clamp(position.x, screenBounds.x * -1 + playerWidth, screenBounds.x - playerWidth);
        position.y = Mathf.Clamp(position.y, screenBounds.y * -1 + playerHeight, screenBounds.y - playerHeight);

        rb.position = position;
    }

    private void CheckMoveFacing()
    {
        // if (movement.x < 0 && facingRight) Flip();
        // else if (movement.x > 0 && !facingRight) Flip();
        
        // Check if the player is moving horizontally
        var isMovingX = movement.x != 0f;

        // Calculate the signs of the player's movement and scale
        var moveSign = Mathf.Sign(movement.x);
        var scaleSign = Mathf.Sign(transform.localScale.x);

        // Check if the movement direction is opposite to the scale direction
        // moveSign != scaleSign ... !Mathf.Approximately(moveSign, scaleSign)
        var isMovingOppositeToFacing = !Mathf.Approximately(moveSign, scaleSign);

        if (isMovingX && isMovingOppositeToFacing) Flip();
    }

    public void IncreaseSpeed(float speedArg)
    {
        moveSpeed = Mathf.Min(moveSpeed + speedArg, maxSpeed);
    }

    private void Flip()
    {
        facingRight = !facingRight;

        transform.localScale = new Vector3(
            -transform.localScale.x,
            transform.localScale.y,
            transform.localScale.z);

        onPlayerFlipped?.Invoke(GetFacingRight());
    }

    private bool GetFacingRight() => facingRight;
}
}