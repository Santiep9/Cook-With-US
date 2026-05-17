using System.Collections;
using Unity.VisualScripting;
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

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        rb.linearVelocity = moveInput * moveSpeed;

        anim.SetFloat("InputX", moveInput.x);
        anim.SetFloat("InputY", moveInput.y);

        anim.SetBool("isMoving", moveInput != Vector2.zero);

        if (context.canceled)
        {
            rb.linearVelocity = Vector2.zero;
        }
    }

    public void PlayWinAnimation()
    {
        rb.linearVelocity = Vector2.zero;

        anim.SetTrigger("Win");
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