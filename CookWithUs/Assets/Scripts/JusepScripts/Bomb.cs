using System;
using System.Collections;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float explodeTime = 3f;

    public event Action OnBombExplode;

    /*Array[][] = {
        {0,0,0},
        {0,0,0},
        {0,0,0}
        }*/

    [Header("Detect Explosion")]
    public Rigidbody2D player;
    public int boomDist;
    public Transform origin;

    private void Start()
    {
        Invoke(nameof(Explode), explodeTime);

        player = GetComponent<Rigidbody2D>();
    }

    private void Explode()
    {
        OnBombExplode.Invoke();
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(origin.position, Vector2.up);
        Debug.DrawLine(origin.position, Vector2.up, Color.red, 3f);
        RaycastHit2D hitInfo2 = Physics2D.Raycast(origin.position, Vector2.down);
        Debug.DrawLine(origin.position, Vector2.down, Color.red, 3f);
        RaycastHit2D hitInfo3 = Physics2D.Raycast(origin.position, Vector2.right);
        Debug.DrawLine(origin.position, Vector2.right, Color.red, 3f);
        RaycastHit2D hitInfo4 = Physics2D.Raycast(origin.position, Vector2.left);
        Debug.DrawLine(origin.position, Vector2.left, Color.red, 3f);

    }
}