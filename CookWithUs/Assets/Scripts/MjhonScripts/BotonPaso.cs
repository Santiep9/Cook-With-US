using TMPro;
using UnityEngine;

public class BotonPaso : MonoBehaviour
{
    public string[] conversacionMjohn;
    public TextMeshProUGUI Text;
    public int frases = 0;
    public void Clickado()
    {
        Text.text = conversacionMjohn[frases];
        frases++;
    }
   
     
    
}
