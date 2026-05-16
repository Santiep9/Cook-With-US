using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MenuPausaController : MonoBehaviour
{
    public GameObject menuPausa;
    public GameObject menuSettings;
    public GameObject exitCanvas;

    public AudioClip[] sonidosSettings;

    public Sprite spriteExitCONFIRMADO;
    public Image exitImage;

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

    public void ContinueGame()
    {
        menuPausa.SetActive(false);
        PauseController.SetPause(menuPausa.activeSelf);
    }
    public void OpenSettings()
    {
        menuSettings.SetActive(true);
    }

    public void ExitSettings()
    {
        menuSettings.SetActive(false);
    }

    public void ExitGame()
    {
        exitCanvas.SetActive(true);
    }

    public void ConfirmExit()
    {
        exitCanvas.SetActive(false);
        exitImage.sprite = spriteExitCONFIRMADO;
        SoundEffectManager.PlayVoice(sonidosSettings[0]);


        //Application.Quit();
    }

    public void DenyExit()
    {
        exitCanvas.SetActive(false);
    }
}
