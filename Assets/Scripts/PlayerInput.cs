using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Camera mainCamera;
    public Rigidbody2D rb;
    public Vector2 move;
    public float speed;
    
    
    void Start()
    {
        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        move.x = Input.GetAxis("Horizontal");
        move.y = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        Vector2 newPosition =  rb.position + move * speed * Time.fixedDeltaTime;
        
        // Clamp the player's position within the camera bounds
        newPosition = ClampPositionToCameraBounds(newPosition);

        // Apply the clamped position
        rb.MovePosition(newPosition);
    }
    
    Vector2 ClampPositionToCameraBounds(Vector2 position)
    {
        // Get the camera's viewport corners in world space
        Vector3 bottomLeft = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, mainCamera.transform.position.z));
        Vector3 topRight = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, mainCamera.transform.position.z));

        // Clamp the position within the camera's bounds
        float clampedX = Mathf.Clamp(position.x, bottomLeft.x, topRight.x);
        float clampedY = Mathf.Clamp(position.y, bottomLeft.y, topRight.y);

        return new Vector2(clampedX, clampedY);
    }
}
