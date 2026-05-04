using TMPro;
using UnityEngine;

public class BotonPaso : MonoBehaviour
{
    public string[] conversacionMjohn;
    public TextMeshProUGUI Text;
    public int frases = 0;
    public GameObject CanvasDialogue;
    public GameObject Canvas;
    public void Clickado()
    {
        Debug.Log("PENE");
        if (frases == 4)
        {
            Canvas.SetActive(true);
            CanvasDialogue.SetActive(false);
        }
        Debug.Log(frases);
        Text.text = conversacionMjohn[frases];
        frases++;
        
    }
   
     
    
}
