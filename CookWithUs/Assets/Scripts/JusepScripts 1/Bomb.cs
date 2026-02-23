using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject bomb;

    void Start()
    {
        Explode();
    }

    void Explode()
    {
        Destroy(bomb, 3.0f);
    }
}
