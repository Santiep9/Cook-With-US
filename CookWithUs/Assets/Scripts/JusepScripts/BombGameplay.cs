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
    public Transform bombPos;
    public float bombOffset = 1f;
    public LayerMask wallLayer;
    public float bombCheckRadius = 0.2f;

    [Header("BombLimit")]
    public int maxBombs = 1;
    private int currentBombs = 0;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Vector2 moveInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        transform.position = SnapToGrid(transform.position);
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
        if (!context.performed) return;
        if (currentBombs >= maxBombs) return;

        Vector2 rawPos = bombPos.position;
        Vector2 spawnPos = SnapToGrid(rawPos);

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
        rb.linearVelocity = new Vector2(moveInput.x * moveSpeed, moveInput.y * moveSpeed);
    }

    private void FlipSprite()
    {
        if (sr == null) return;
        if (moveInput.sqrMagnitude < 0.01f) return;

        if (Mathf.Abs(moveInput.x) > Mathf.Abs(moveInput.y))
        {
            if (moveInput.x < 0)
            {
                sr.flipX = true;
                bombPos.localPosition = new Vector3(-bombOffset, 0f, 0f);
            }
            else
            {
                sr.flipX = false;
                bombPos.localPosition = new Vector3(bombOffset, 0f, 0f);
            }
        }
        else
        {
            if (moveInput.y > 0)
            {
                bombPos.localPosition = new Vector3(0f, bombOffset, 0f);
            }
            else
            {
                bombPos.localPosition = new Vector3(0f, -bombOffset, 0f);
            }
        }
    }

    private void HandleBombExplode()
    {
        currentBombs = Mathf.Max(0, currentBombs - 1);
    }

    public void Die()
    {
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