using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        public Vector2 playerAimingVector;
        public float moveSpeed;
        public float maxSpeed;

        private Camera mainCamera;
        private Vector2 screenBounds;
        private float playerWidth;
        private float playerHeight;

        private Rigidbody2D rb;
        private Vector2 movement;

        private void Start()
        {
            mainCamera = Camera.main;
        
            // Calculate the screen bounds
            screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));

            var player = FindObjectOfType<Player>();
        
            // Get the player collider 2D component and calculate the size
            var playerCollider = player.GetComponent<CapsuleCollider2D>();
            playerWidth = playerCollider.bounds.extents.x * 2;
            playerHeight = playerCollider.bounds.extents.y * 2;
        
            rb = player.GetComponent<Rigidbody2D>();
            moveSpeed = player.playerSpeed;
            playerAimingVector = Vector2.right;
        }

        private void FixedUpdate()
        {
            // Handle player input
            movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            var moveVelocity = movement * moveSpeed;
        
            // Apply movement
            rb.velocity = moveVelocity;
        
            // Constrain the player within the screen bounds
            var position = rb.position;
            position.x = Mathf.Clamp(position.x, screenBounds.x * -1 + playerWidth, screenBounds.x - playerWidth);
            position.y = Mathf.Clamp(position.y, screenBounds.y * -1 + playerHeight, screenBounds.y - playerHeight);
        
            rb.position = position;

            CheckPlayerAiming();
        }

        private void CheckPlayerAiming()
        {
            if (movement.x > 0)
                SetPlayerAiming(Vector2.right);
            else if (movement.x < 0)
                SetPlayerAiming(Vector2.left);
            else if (movement.y > 0)
                SetPlayerAiming(Vector2.up);
            else if (movement.y < 0)
                SetPlayerAiming(Vector2.down);
            else SetPlayerAiming(playerAimingVector);
        }

        private void SetPlayerAiming(Vector2 vector) => playerAimingVector = vector;
        public Vector2 GetPlayerAiming() => playerAimingVector;

        public void IncreaseSpeed(float speedArg)
        {
            Debug.Log("Prev speed: " + moveSpeed);
            moveSpeed += speedArg;
            if (moveSpeed > maxSpeed) moveSpeed = maxSpeed;
            Debug.Log("Curr speed: " + moveSpeed);
        }
    }
}