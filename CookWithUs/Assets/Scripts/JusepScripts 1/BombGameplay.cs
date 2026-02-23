using UnityEngine;
using UnityEngine.InputSystem;

public class BombGameplay : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 2f;

    [Header("Bomb")]
    public GameObject bomb;
    public Transform bombPos;

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

    public void DropBomb(InputAction.CallbackContext context)
    {
        GameObject newBomb = Instantiate(bomb, bombPos);
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
