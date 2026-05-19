using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Rendering;

public class ButtonsMenu : MonoBehaviour
{
    public Areas areas;
    public DoorData doorData;
    public GameObject timeline;
    public GameObject settingsPanel;
    public AudioClip Sqish;
    public NPCDialogue dialogueData;


    public void NewGame()
    {
        areas.pirulinCompleted = false;
        areas.jusepCompleted = false;
        areas.mjohnCompleted = false;

        areas.pirulinSelected = false;
        areas.jusepSelected = false;
        areas.mjohnSelected = false;

        doorData.puertaMJohn = false;
        doorData.puertaJusep = false;
        doorData.puertaRestaurante = false;

        dialogueData.primeraConverLibro = true;

        AudioClip audiotoplay = Sqish;
        SoundEffectManager.PlayVoice(audiotoplay);
        Debug.Log("Playing sound: " + audiotoplay.name);

        timeline.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    public void Settings()
    {
        settingsPanel.SetActive(true);
        AudioClip audiotoplay = Sqish;
        SoundEffectManager.PlayVoice(audiotoplay);
        Debug.Log("Playing sound: " + audiotoplay.name);
    }
    public void CloseSettings()
    {
        settingsPanel.SetActive(false);

    }

}
