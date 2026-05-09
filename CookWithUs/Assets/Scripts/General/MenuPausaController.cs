using UnityEngine;
using UnityEngine.InputSystem;

public class MenuPausaController : MonoBehaviour
{
    public GameObject menuPausa;

    private void Start()
    {
        menuPausa.SetActive(false);
    }

    public void MenuPausa(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if(!menuPausa.activeSelf && PauseController.IsGamePaused)
            {
                return;
            }
            menuPausa.SetActive(!menuPausa.activeSelf);
            PauseController.SetPause(menuPausa.activeSelf);
        }
    }
}
