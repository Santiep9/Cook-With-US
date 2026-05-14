using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalDelJuego : MonoBehaviour
{
    public GameObject Mover;
    public float TiempoEscena;
    public string NombreEscena;
    void Start()
    {
        
    }

    void Update()
    {
        TiempoEscena -= Time.deltaTime;
        if (TiempoEscena <= 13.5)
        {
            Mover.transform.position += 0.4f * Vector3.up;
        }
        if (TiempoEscena <= 0)
        {
            SceneManager.LoadScene(NombreEscena);
        }
    }
}
