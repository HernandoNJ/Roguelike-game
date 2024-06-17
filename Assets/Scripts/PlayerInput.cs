using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Camera mainCamera;
    public Rigidbody2D rb;
    public Vector2 playerAimingVector;
    public float moveSpeed;
    public Collider2D playerCollider;
    
    private Vector2 screenBounds;
    private Vector2 movement;
    private float objWidth;
    private float objHeight;
    
    private void Start()
    {
        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = GetComponent<Player>().playerSpeed;
        playerAimingVector = Vector2.right;
        var bounds = playerCollider.bounds;
        objWidth = bounds.size.x * transform.localScale.x;
        objHeight = bounds.size.y * transform.localScale.y;
    }

    private void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        // Clamp the player's position within the camera bounds
        Vector2 newPosition =  rb.position + movement * (moveSpeed * Time.fixedDeltaTime);
        //newPosition = ClampPositionToCameraBounds(newPosition);
        rb.MovePosition(newPosition);
        rb.AddForce(newPosition, ForceMode2D.Impulse);
        //ClampPositionToCameraBounds(newPosition);
        CheckPlayerAiming();

        //float angle = Mathf.Atan2(fireDirection.y, fireDirection.x) * Mathf.Rad2Deg - 90f; // in case this offset of 90 is needed
        // rb.rotation = angle;
    }

    // Vector2 ClampPositionToCameraBounds(Vector2 position)
    // {
    //     // Get the camera's viewport corners in world space
    //     var bottomLeft = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, mainCamera.transform.position.z));
    //     var topRight = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, mainCamera.transform.position.z));
    //
    //     // Clamp the position within the camera's bounds
    //     var clampedX = Mathf.Clamp(objWidth, bottomLeft.x, topRight.x);
    //     var clampedY = Mathf.Clamp(objHeight, bottomLeft.y, topRight.y);
    //
    //     return new Vector2(clampedX, clampedY);
    // }

    private void CheckPlayerAiming()
    {
        if (movement.x > 0)
            SetPlayerAiming(Vector2.right);
        else if(movement.x < 0)
            SetPlayerAiming(Vector2.left);
        else if (movement.y > 0)
            SetPlayerAiming(Vector2.up);
        else if (movement.y < 0)
            SetPlayerAiming(Vector2.down);
        else SetPlayerAiming(playerAimingVector);
    }

    private void CheckScreenBounds()
    {
        var objPos = transform.position;
        objPos.x = Mathf.Clamp(objPos.x, screenBounds.x * -1 + objWidth, screenBounds.x - objWidth);
        objPos.y = Mathf.Clamp(objPos.y, screenBounds.y * -1 + objHeight, screenBounds.y - objHeight);
        transform.position = objPos;
    }
    
    private void SetPlayerAiming(Vector2 vector) => playerAimingVector = vector;
    public Vector2 GetPlayerAiming() => playerAimingVector;
}
