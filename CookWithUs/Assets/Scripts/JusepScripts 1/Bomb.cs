using System;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float explodeTime = 3f;

    public event Action OnBombExplode;

    private void Start()
    {
        Invoke(nameof(Explode), explodeTime);
    }

    private void Explode()
    {
        OnBombExplode.Invoke();
        Destroy(gameObject);
    }
}