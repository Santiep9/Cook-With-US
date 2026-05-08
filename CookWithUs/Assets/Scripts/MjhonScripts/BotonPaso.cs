using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonPaso : MonoBehaviour
{
    public string[] conversacionMjohn;
    public TextMeshProUGUI Text;
    public int frases = 0;
    public GameObject CanvasDialogue;
    public GameObject Canvas;
    public string NombreEscena;


    public void Clickado()
    {
        if (frases == 4)
        {
            if (Canvas==null)
            {
                SceneManager.LoadScene(NombreEscena);
            }
            if (Canvas!=null)
            {
                Canvas.SetActive(true);
                CanvasDialogue.SetActive(false);
            }               
        }
        Text.text = conversacionMjohn[frases];
        frases++;        
    }     
}
