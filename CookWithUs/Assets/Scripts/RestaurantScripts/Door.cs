using System.Threading.Tasks;
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
            //FadeTransition(other.gameObject);
            SceneManager.LoadScene(NombreEscena);
        }
    }

    /*async void FadeTransition(GameObject player)
    {
        PauseController.SetPause(true);

        await ScreenFader.Instance.FadeOut();

        

        await Task.Yield();

        await ScreenFader.Instance.FadeIn();

        PauseController.SetPause(false);
    }*/
}
