using UnityEngine;

public class BotonTimeline : MonoBehaviour
{
    public GameObject CanvasDialogue;
    public GameObject Timeline;

    public InteractDialogo interactDialogo;
    public void OnClick()
    {
        if (Timeline != null)
        {
            Timeline.SetActive(true);
        }

        SoundEffectManager.StopVoice();
        interactDialogo.EndDialogue();
    }
}
