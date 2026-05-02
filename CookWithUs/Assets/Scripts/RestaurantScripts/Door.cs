using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField] public string NombreEscena;

    public DoorData doorData;

    private void OnTriggerEnter2D(Collider2D other)
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
