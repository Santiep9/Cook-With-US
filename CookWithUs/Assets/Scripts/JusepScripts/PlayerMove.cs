using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 2f;
    public float jumpForce = 5f;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Vector2 moveInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        Move();
        FlipSprite();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    private void Move()
    {
        rb.linearVelocity = new Vector2(moveInput.x * moveSpeed, moveInput.y * moveSpeed);
    }

    private void FlipSprite()
    {
        if (sr == null) return;

        if (moveInput.x < -0.01f) sr.flipX = true;
        else if (moveInput.x > 0.01f) sr.flipX = false;
    }
}
