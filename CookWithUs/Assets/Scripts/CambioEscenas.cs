using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
public class CambioEscenas : MonoBehaviour
{
    public float TiempoEscena;
    public string NombreEscena;
   

    void Update()
    {
        TiempoEscena -= Time.deltaTime;
        if (TiempoEscena <= 0)
        {
            SceneManager.LoadScene(NombreEscena);
        }
    }
}
