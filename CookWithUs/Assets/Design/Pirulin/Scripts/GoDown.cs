using UnityEngine;

public class GoDown : MonoBehaviour
{
    public float speed = 2f;

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
}
