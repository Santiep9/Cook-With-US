using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class BombGameplay : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 2f;

    [Header("Bomb")]
    public GameObject bomb;
    public LayerMask wallLayer;
    public float bombCheckRadius = 0.2f;

    [Header("BombLimit")]
    public int maxBombs = 1;
    private int currentBombs = 0;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Vector2 moveInput;

    private Animator anim;
    private bool isDead = false;
    public bool isBusy = false;
    private Vector2 lastMoveDir = Vector2.down;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        transform.position = SnapToGrid(transform.position);
    }

    private void FixedUpdate()
    {
        Move();
        FlipSprite();
        UpdateAnimations();
    }

    void UpdateAnimations()
    {
        bool isMoving = moveInput.sqrMagnitude > 0.01f;

        if (isMoving)
        {
            if (Mathf.Abs(moveInput.x) > Mathf.Abs(moveInput.y))
            {
                lastMoveDir = new Vector2(Mathf.Sign(moveInput.x), 0);
            }
            else
            {
                lastMoveDir = new Vector2(0, Mathf.Sign(moveInput.y));
            }
        }

        anim.SetFloat("MoveX", lastMoveDir.x);
        anim.SetFloat("MoveY", lastMoveDir.y);
        anim.SetBool("IsMoving", isMoving);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void DropBomb(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        if (currentBombs >= maxBombs) return;

        Vector2 spawnPos = SnapToGrid(transform.position);

        Collider2D hit = Physics2D.OverlapCircle(spawnPos, bombCheckRadius, wallLayer);
        if (hit != null) return;

        GameObject newBomb = Instantiate(bomb, spawnPos, Quaternion.identity);

        currentBombs++;

        Bomb bombScript = newBomb.GetComponent<Bomb>();
        if (bombScript != null)
        {
            bombScript.OnBombExplode += HandleBombExplode;
        }
    }

    private void Move()
    {
        if (isDead || isBusy)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        rb.linearVelocity = new Vector2(moveInput.x * moveSpeed, moveInput.y * moveSpeed);
    }

    public void PlayWinAnimation()
    {
        if (isBusy) return;

        isBusy = true;

        rb.linearVelocity = Vector2.zero;

        anim.SetTrigger("Win");
    }

    private void FlipSprite()
{
    if (moveInput.x < 0)
    {
        sr.flipX = true;
    }
    else if (moveInput.x > 0)
    {
        sr.flipX = false;
    }
}

    private void HandleBombExplode()
    {
        currentBombs = Mathf.Max(0, currentBombs - 1);
    }

    public void Die()
    {
        if (isDead) return;

        isDead = true;

        rb.linearVelocity = Vector2.zero;

        anim.SetTrigger("Die");

        StartCoroutine(RestartScene());
    }

    IEnumerator RestartScene()
    {
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    Vector2 SnapToGrid(Vector2 pos)
    {
        return new Vector2(Mathf.Round(pos.x), Mathf.Round(pos.y));
    }
}