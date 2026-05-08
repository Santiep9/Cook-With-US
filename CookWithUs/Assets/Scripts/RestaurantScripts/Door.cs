using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField] public string NombreEscena;

    public DoorData doorData;

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch(NombreEscena)
        {
            case "Jusep Area":
                doorData.puertaJusep = true;
                doorData.puertaMJohn = false;
                doorData.puertaRestaurante = false;
                break;
            case "MJohn Area":
                doorData.puertaMJohn = true;
                doorData.puertaJusep = false;
                doorData.puertaRestaurante = false;
                break;
            case "Restaurant":
                doorData.puertaRestaurante = true;
                doorData.puertaJusep = false;
                doorData.puertaMJohn = false;
                break;
        }

        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(NombreEscena);
        }
    }
}
