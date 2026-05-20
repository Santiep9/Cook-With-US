using System.Collections;
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
        SoundEffectManager.PlayVoice(sonidosSettings[0]);
    }

    public void ConfirmExit()
    {
        exitCanvas.SetActive(false);
        exitImage.sprite = spriteExitCONFIRMADO;
        SoundEffectManager.PlayVoice(sonidosSettings[1]);

        StartCoroutine(QuitAfterSound(sonidosSettings[1].length));
    }

    private IEnumerator QuitAfterSound(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);

        Application.Quit();

        
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }


    public void DenyExit()
    {
        exitCanvas.SetActive(false);
        SoundEffectManager.StopVoice();
    }
}
