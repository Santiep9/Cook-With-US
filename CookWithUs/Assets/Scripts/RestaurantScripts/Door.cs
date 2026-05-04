using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField] public string NombreEscena;

    public DoorData doorData;

    private void OnTriggerEnter2D(Collider2D other)
    //Hola  soy alex, podeis usar switches y tal chavales sois el spaghetti code final boss, no os cortéis, dadle caña al código, que el código es vida, el código es amor, el código es lo que nos une a todos en esta aventura de desarrollo de videojuegos, así que adelante, hacedlo con pasión y sin miedo a romper cosas, porque al final del día, lo importante es crear algo increíble juntos.
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(NombreEscena);

        }
        if(NombreEscena == "Jusep Area")
        {
            doorData.puertaJusep = true;
            doorData.puertaMJohn = false;
            doorData.puertaRestaurante = false;
        }
        if(NombreEscena == "MJohn Area")
        {
            doorData.puertaMJohn = true;
            doorData.puertaJusep = false;
            doorData.puertaRestaurante = false;
        }
        if(NombreEscena == "Restaurant")
        {
            doorData.puertaRestaurante = true;
            doorData.puertaJusep = false;
            doorData.puertaMJohn = false;
        }
    }
}
