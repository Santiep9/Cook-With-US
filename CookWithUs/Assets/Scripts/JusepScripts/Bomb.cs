using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bomb : MonoBehaviour
{
    public float explodeTime = 3f;

    public event Action OnBombExplode;

    private Collider2D bombCollider;

    [Header("Explosion Settings")]
    public int boomDist = 3;
    public Transform origin;
    public LayerMask collisionMask;

    public Areas areas;

    private void Start()
    {
        bombCollider = GetComponent<Collider2D>();

        bombCollider.enabled = false;

        Invoke(nameof(EnableCollider), 1f);
        Invoke(nameof(Explode), explodeTime);
    }

    private void Explode()
    {
        ExplodeDirection(Vector2.up);
        ExplodeDirection(Vector2.down);
        ExplodeDirection(Vector2.right);
        ExplodeDirection(Vector2.left);

        OnBombExplode?.Invoke();
        Destroy(gameObject);
    }

    void ExplodeDirection(Vector2 direction)
    {
        for (int i = 1; i <= boomDist; i++)
        {
            Vector2 checkPos = (Vector2)origin.position + direction * i;

            Debug.DrawLine(origin.position, checkPos, Color.red, 1f);

            Collider2D col = Physics2D.OverlapBox(checkPos, Vector2.one * 0.8f, 0f);

            if (col != null)
            {
                if (col.CompareTag("Player"))
                {
                    col.GetComponent<BombGameplay>().Die();  
                }

                if (col.CompareTag("Enemy"))
                {
                    Destroy(col.gameObject);
                    areas.jusepCompleted = true;
                    SceneManager.LoadScene("Restaurant");
                }

                if (col.CompareTag("Breakable"))
                {
                    Destroy(col.gameObject);
                    break;
                }

                if (col.gameObject.layer == LayerMask.NameToLayer("Wall"))
                {
                    break;
                }
            }
        }
    }

    void EnableCollider()
    {
        bombCollider.enabled = true;
    }
}