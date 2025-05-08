using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
public class PlayerMove2d: MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Vector2 moveInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = moveInput * (moveSpeed);
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
}
}