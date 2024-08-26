using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class PlayerMovement2 : MonoBehaviour
{
    [SerializeField] private PlayerInput m_playerInput;
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

    private InputAction m_LookAction;
    private InputAction m_MoveAction;
    private InputAction m_FireAction;

    private void Awake()
    {
        m_playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        ConfigInputActions();
        EnablePlayerInput();
    }

    private void OnDisable()
    {
        DisablePlayerInput();
    }

    private void Start()
    {
        ConfigMainCamera();
        ConfigPlayerCollider();

        // Ensure the player is facing the correct direction
        if (!facingRight) Flip();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void ConfigInputActions()
    {
        if (m_playerInput == null)
        {
            m_playerInput = GetComponent<PlayerInput>();
            m_FireAction = m_playerInput.actions["Fire"];
            m_LookAction = m_playerInput.actions["Look"];
            m_MoveAction = m_playerInput.actions["Move"];
        }
    }

    private void EnablePlayerInput()
    {
        m_FireAction.performed += OnFire;
        m_MoveAction.performed += OnMove;
        m_LookAction.performed += OnLook;

        m_playerInput.enabled = true;
    }

    private void DisablePlayerInput()
    {
        m_FireAction.performed -= OnFire;
        m_MoveAction.performed -= OnMove;
        m_LookAction.performed -= OnLook;

        m_playerInput.enabled = false;
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

    private void OnLook(InputAction.CallbackContext context)
    {
        Debug.Log($"{context.action} performed");
        Debug.Log("Player is looking");
    }

    private void OnFire(InputAction.CallbackContext context)
    {
        Debug.Log($"{context.action} performed");
        Debug.Log("Player is firing");
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
        CheckMoveFacing();
    }
    
    private void MovePlayer()
    {
        rb.velocity = movement * moveSpeed;

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

        onPlayerFlipped?.Invoke(facingRight);
    }

    public bool GetFacingRight() => facingRight;
}