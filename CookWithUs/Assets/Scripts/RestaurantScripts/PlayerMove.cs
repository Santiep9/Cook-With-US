using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 2f;

    public Rigidbody2D rb;
    private SpriteRenderer sr;
    private Vector2 moveInput;

    public bool canMove = true;


    private bool playingFootsteps = false;
    public float footstepInterval = 0.5f;

    private Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (PauseController.IsGamePaused)
        {
            animator.SetBool("IsMoving", false);
        }

    }

    private void FixedUpdate()
    {
        //necesitamos un escape para parar el juego y que pare el movimiento y llamar a stopfootsteps(Sonido), parar la animacion, etc...
        if (PauseController.IsGamePaused)
        {
            StopFootSteps();
            rb.linearVelocity = Vector2.zero;
            return;
        }
        Move();
        FlipSprite();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    private void Move()
    {

        if (canMove != false)
        {         
            rb.linearVelocity = new Vector2(moveInput.x * moveSpeed, moveInput.y * moveSpeed);
        }
        if(rb.linearVelocity.magnitude > 0.01f && !playingFootsteps)
        {
            animator.SetBool("IsMoving", true);
            StartFootSteps();
        }
        else if(rb.linearVelocity.magnitude <= 0.01f && playingFootsteps)
        {
            StopFootSteps();
            animator.SetBool("IsMoving", false);
        }
    }

    private void FlipSprite()
    {
        if (sr == null) return;

        if (moveInput.x < -0.01f) sr.flipX = true;
        else if (moveInput.x > 0.01f) sr.flipX = false;
    }

    void StartFootSteps()
    {
        playingFootsteps = true;
        InvokeRepeating(nameof(PlayFootStep), 0f, footstepInterval);
        SoundEffectManager.Play("Walk");
    }

     public void StopFootSteps()
    {
        playingFootsteps = false;
        CancelInvoke(nameof(PlayFootStep));
    }

    void PlayFootStep()
    {
        SoundEffectManager.Play("Walk", true);
    }
}
