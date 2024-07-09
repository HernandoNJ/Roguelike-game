using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private float maxSpeed; 
        [SerializeField] private bool facingRight;
        
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
            moveSpeed = player.GetPlayerSpeed();

            CheckFacingRight();
        }

        private void FixedUpdate()
        {
            MovePlayer();
        }

        private void MovePlayer()
        {
            // Handle player input
            var moveH = Input.GetAxis("XAxisKeys");
            var moveV = Input.GetAxis("YAxisKeys");

            if(moveH < 0 && facingRight) Flip();
            else if(moveH > 0 && !facingRight) Flip();
            
            movement = new Vector2(moveH, moveV);
            
            // Apply movement
            rb.velocity = movement * moveSpeed;
        
            // Constrain the player within the screen bounds
            var position = rb.position;
            position.x = Mathf.Clamp(position.x, screenBounds.x * -1 + playerWidth, screenBounds.x - playerWidth);
            position.y = Mathf.Clamp(position.y, screenBounds.y * -1 + playerHeight, screenBounds.y - playerHeight);
        
            rb.position = position;
        }

        public void IncreaseSpeed(float speedArg)
        {
            moveSpeed += speedArg;
            if (moveSpeed > maxSpeed) moveSpeed = maxSpeed;
        }

        private void Flip()
        {
            facingRight = !facingRight;
            transform.Rotate(0,180,0);
        }
        
        private void CheckFacingRight()
        {
            if (transform.rotation.y == 0) facingRight = true;
            else if (Mathf.Approximately(transform.rotation.y, 180f)) facingRight = false;
        }

        public bool GetFacingRight() => facingRight;
    }
}