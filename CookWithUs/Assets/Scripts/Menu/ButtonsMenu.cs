using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsMenu : MonoBehaviour
{
    public Areas areas;
    public DoorData doorData;
    public GameObject timeline;

    public void NewGame()
    {
        areas.pirulinCompleted = false;
        areas.jusepCompleted = false;
        areas.mjohnCompleted = false;
        doorData.puertaMJohn = false;
        doorData.puertaJusep = false;
        doorData.puertaRestaurante = false;

        timeline.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
