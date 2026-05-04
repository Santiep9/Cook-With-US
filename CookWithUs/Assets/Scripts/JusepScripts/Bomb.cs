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

    [Header("Explosion Visuals")]
    public GameObject explosionCenterPrefab;
    public GameObject explosionMiddlePrefab;
    public GameObject explosionEndPrefab;

    public float explosionDuration = 0.5f;

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
        GameObject center = Instantiate(explosionCenterPrefab, origin.position, Quaternion.identity);
        Destroy(center, explosionDuration);
        Destroy(gameObject);
    }

    void ExplodeDirection(Vector2 direction)
    {
        for (int i = 1; i <= boomDist; i++)
        {
            Vector2 checkPos = (Vector2)origin.position + direction * i;

            Collider2D col = Physics2D.OverlapBox(checkPos, Vector2.one * 0.8f, 0f);

            bool isEnd = false;

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
                    isEnd = true;
                }

                if (col.gameObject.layer == LayerMask.NameToLayer("Wall"))
                {
                    break;
                }
            }

            GameObject prefabToSpawn = (i == boomDist || isEnd)
                ? explosionEndPrefab
                : explosionMiddlePrefab;

            Quaternion rot = Quaternion.identity;

            if (direction == Vector2.right) rot = Quaternion.Euler(0, 0, 0);
            if (direction == Vector2.left) rot = Quaternion.Euler(0, 0, 180);
            if (direction == Vector2.up) rot = Quaternion.Euler(0, 0, 90);
            if (direction == Vector2.down) rot = Quaternion.Euler(0, 0, -90);

            GameObject explosion = Instantiate(prefabToSpawn, checkPos, rot);

            Destroy(explosion, explosionDuration);

            if (isEnd) break;
        }
    }

    void EnableCollider()
    {
        bombCollider.enabled = true;
    }
}