using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class ConversacionFinal : MonoBehaviour
{
    public string[] dialogos;

    public int dialogoIndex = 0;

    public TMP_Text Text;

    public GameObject Timeline;
    void Start()
    {
        
    }

    void Update()
    {
        if(Keyboard.current.eKey.wasPressedThisFrame)
        {
            if(dialogoIndex >= dialogos.Length)
            {
                Timeline.gameObject.SetActive(true);
            }
            Text.text = dialogos[dialogoIndex];
              dialogoIndex++;
        }
    }
}
