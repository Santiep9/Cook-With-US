using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsMenu : MonoBehaviour
{
    public Areas areas;

    public void NewGame()
    {
        areas.pirulinCompleted = false;
        areas.jusepCompleted = false;
        areas.mjohnCompleted = false;

        SceneManager.LoadScene("Restaurant");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
