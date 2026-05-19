using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMove : MonoBehaviour
{
    [Header("Referencias")]
    public Transform player;
    public GameObject bombPrefab;
    public Areas areas;

    [Header("Movimiento")]
    public float moveSpeed = 5f;

    [Header("IA")]
    public float thinkRate = 0.2f;

    [Header("Vidas")]
    public int maxLives = 3;

    private static int currentLives;
    private static bool initialized = false;

    [Header("Vidas UI")]
    public SpriteRenderer[] lifeRenderers;
    public Sprite lifeOn;
    public Sprite lifeOff;

    private Vector2 targetPos;
    private float thinkTimer;

    private GameObject currentBomb;
    private bool isEscaping = false;
    private Vector2 escapeTarget;

    private Animator anim;
    private Vector2 moveDir;

    [SerializeField] AudioClip VFX;

    Vector2[] directions = new Vector2[]
    {
        Vector2.up,
        Vector2.down,
        Vector2.left,
        Vector2.right
    };

    void Awake()
    {
        if (!initialized)
        {
            currentLives = maxLives;
            initialized = true;
        }

        UpdateLifeUI();
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        targetPos = SnapToGrid(transform.position);
        transform.position = targetPos;
        AudioClip Won = VFX;
        SoundEffectManager.PlayVoice(Won);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            targetPos,
            moveSpeed * Time.deltaTime
        );

        bool moving = Vector2.Distance(transform.position, targetPos) > 0.01f;

        anim.SetBool("isMoving", moving);
    }

    void FixedUpdate()
    {
        if (isEscaping)
        {
            MoveTo(escapeTarget);

            if (Vector2.Distance(transform.position, escapeTarget) < 0.1f)
            {
                isEscaping = false;
            }

            return;
        }

        thinkTimer += Time.deltaTime;

        if (thinkTimer >= thinkRate)
        {
            MoveTowardsPlayer();
            thinkTimer = 0;
        }
    }

    void MoveTowardsPlayer()
    {
        Vector2 myPos = SnapToGrid(transform.position);
        Vector2 playerPos = SnapToGrid(player.position);

        Vector2 bestMove = myPos;
        Vector2 bestDir = Vector2.zero;
        float bestDist = Mathf.Infinity;

        foreach (Vector2 dir in directions)
        {
            for (int i = 1; i <= 2; i++)
            {
                Vector2 checkPos = myPos + dir * i;

                if (IsBreakable(checkPos))
                {
                    TryPlaceBomb(dir);
                    return;
                }

                if (!IsWalkable(checkPos))
                    break;
            }

            Vector2 nextPos = myPos + dir;

            if (!IsWalkable(nextPos)) continue;

            float dist = Vector2.Distance(nextPos, playerPos);

            if (dist < bestDist)
            {
                bestDist = dist;
                bestMove = nextPos;
                bestDir = dir;
            }
        }

        if (Vector2.Distance(myPos, playerPos) <= 1.1f)
        {
            TryPlaceBomb(bestDir);
            return;
        }

        MoveTo(bestMove);
    }

    void MoveTo(Vector2 pos)
    {
        moveDir = (pos - (Vector2)transform.position).normalized;

        if (moveDir != Vector2.zero)
        {
            anim.SetFloat("InputX", moveDir.x);
            anim.SetFloat("InputY", moveDir.y);

            anim.SetFloat("LastInputX", moveDir.x);
            anim.SetFloat("LastInputY", moveDir.y);
        }

        anim.SetBool("isMoving", true);

        targetPos = pos;
    }

    Vector2 SnapToGrid(Vector2 pos)
    {
        return new Vector2(Mathf.Round(pos.x), Mathf.Round(pos.y));
    }

    bool IsWalkable(Vector2 pos)
    {
        Collider2D col = Physics2D.OverlapBox(pos, Vector2.one * 0.8f, 0f);

        if (col == null) return true;

        if (col.CompareTag("Breakable")) return false;
        if (col.CompareTag("Bomb")) return false;
        if (col.gameObject.layer == LayerMask.NameToLayer("Wall")) return false;

        return true;
    }

    bool IsBreakable(Vector2 pos)
    {
        Collider2D col = Physics2D.OverlapBox(pos, Vector2.one * 0.8f, 0f);
        return col != null && col.CompareTag("Breakable");
    }

    void TryPlaceBomb(Vector2 direction)
    {
        if (currentBomb != null) return;

        Vector2 myPos = SnapToGrid(transform.position);
        Vector2 bombPos = myPos + direction;

        if (!IsWalkable(bombPos)) return;

        if (!CanEscapeAfterBomb(bombPos)) return;

        currentBomb = Instantiate(bombPrefab, bombPos, Quaternion.identity);

        Bomb bombScript = currentBomb.GetComponent<Bomb>();
        bombScript.OnBombExplode += () => currentBomb = null;

        isEscaping = true;
        CalculateEscapeTarget();
    }

    bool CanEscapeAfterBomb(Vector2 bombPos)
    {
        Queue<Vector2> queue = new Queue<Vector2>();
        HashSet<Vector2> visited = new HashSet<Vector2>();

        queue.Enqueue(bombPos);
        visited.Add(bombPos);

        while (queue.Count > 0)
        {
            Vector2 current = queue.Dequeue();

            if (!IsInBombRange(current))
                return true;

            foreach (Vector2 dir in directions)
            {
                Vector2 next = current + dir;

                if (visited.Contains(next)) continue;
                if (!IsWalkable(next)) continue;

                visited.Add(next);
                queue.Enqueue(next);
            }
        }

        return false;
    }

    void CalculateEscapeTarget()
    {
        Vector2 start = SnapToGrid(transform.position);

        Queue<Vector2> queue = new Queue<Vector2>();
        HashSet<Vector2> visited = new HashSet<Vector2>();

        queue.Enqueue(start);
        visited.Add(start);

        while (queue.Count > 0)
        {
            Vector2 current = queue.Dequeue();

            if (!IsInBombRange(current) && IsWalkable(current))
            {
                escapeTarget = current;
                return;
            }

            foreach (Vector2 dir in directions)
            {
                Vector2 next = current + dir;

                if (visited.Contains(next)) continue;
                if (!IsWalkable(next)) continue;

                visited.Add(next);
                queue.Enqueue(next);
            }
        }

        escapeTarget = start;
    }

    bool IsInBombRange(Vector2 pos)
    {
        if (currentBomb == null) return false;

        Vector2 bombPos = SnapToGrid(currentBomb.transform.position);

        if (pos.x == bombPos.x)
        {
            float dist = Mathf.Abs(pos.y - bombPos.y);

            if (dist <= 3)
                return true;
        }

        if (pos.y == bombPos.y)
        {
            float dist = Mathf.Abs(pos.x - bombPos.x);

            if (dist <= 3)
                return true;
        }

        return false;
    }

    public void TakeDamage()
    {
        BombGameplay playerScript = player.GetComponent<BombGameplay>();

        if (playerScript != null)
        {
            playerScript.PlayWinAnimation();
        }

        anim.SetTrigger("Lose");
        enabled = false;

        currentLives--;

        UpdateLifeUI();

        StartCoroutine(HandleDamageSequence());
    }

    IEnumerator HandleDamageSequence()
    {
        yield return new WaitForSeconds(1.5f);

        if (currentLives <= 0)
        {
            initialized = false;

            if (areas != null)
            {
                areas.jusepCompleted = true;
            }

            SoundEffectManager.StopVoice();
            SceneManager.LoadScene("Restaurant");
        }
        else
        {
            SoundEffectManager.StopVoice();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void UpdateLifeUI()
    {
        for (int i = 0; i < lifeRenderers.Length; i++)
        {
            if (i < currentLives)
            {
                lifeRenderers[i].sprite = lifeOn;
            }
            else
            {
                lifeRenderers[i].sprite = lifeOff;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(SnapToGrid(transform.position), Vector2.one * 0.8f);
    }
}