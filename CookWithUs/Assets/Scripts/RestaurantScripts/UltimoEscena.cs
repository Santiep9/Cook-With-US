using UnityEngine;
using UnityEngine.SceneManagement;

public class UltimoEscena : MonoBehaviour
{
    public float TiempoEscena;

    void Update()
    {
        TiempoEscena -= Time.deltaTime;
        if (TiempoEscena <= 0)
        {
            SceneManager.LoadScene("CREDITOS");
        }
    }
}
