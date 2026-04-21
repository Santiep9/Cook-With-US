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
    Rigidbody2D player;
    int fireDist;
    Transform firePoint;
    LineRenderer lineRenderer;

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

    /*private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(firePoint.position, firePoint.right, fireDist);

        if (hit != null)
        {
            if (hit == GameObject.FindGameObjectWithTag("Player"))
            {
                lineRenderer.enabled = true;
                StartCoroutine(Shoot1());
                Debug.Log("Player");
            }
            else if (hit == GameObject.FindGameObjectWithTag("obstacle"))
            {
                //lineRenderer.enabled = false;
                Debug.Log("obstacle");
            }
        }
    }

    IEnumerator Shoot1()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right, shootDist, hittableLayer);

        if (hitInfo != null)
        {
            HealthBar health = hitInfo.transform.GetComponent<HealthBar>();

            if (health != null)
            {
                health.TakeDamage(damage);
            }
            Instantiate(impactEffect, hitInfo.point, Quaternion.identity);

            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, hitInfo.point);

            Debug.Log("shoot");
        }

        lineRenderer.enabled = true;

        yield return new WaitForSeconds(0.02f);

        lineRenderer.enabled = false;
    }*/
}