using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField] public string NombreEscena;

    public DoorData doorData;

    public Areas areas;

    public PlayerMove playerMove;

    public Canvas Completed;

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
            if (areas == null)
            {
                SceneManager.LoadScene(NombreEscena);

            }
            //FadeTransition(other.gameObject);
            if (areas != null && areas.pirulinCompleted && areas.mjohnCompleted && areas.jusepCompleted)
            {
                    Debug.Log("Todas las areas completadas, mostrando mensaje de completado");
                    Completed.gameObject.SetActive(true);
                    playerMove.canMove = false;
                    playerMove.StopFootSteps();
                    playerMove.rb.linearVelocity = Vector2.zero;
                    return;                                    
            }

               SceneManager.LoadScene(NombreEscena);

        }
    }

    public void HideCanvas()
    {
        Completed.gameObject.SetActive(false);
        playerMove.canMove = true;
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
