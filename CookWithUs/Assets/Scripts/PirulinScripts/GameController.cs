using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    int progressAmount;
    public Slider progressSlider;
    public int contadorDerrota = 0;
    public GameObject tryAgain;

    private void Start()
    {

        progressAmount = 0;
        progressSlider.value = 0;
        Botones.OnPointsAdded += IncreaseProgressAmount;
    }
    void IncreaseProgressAmount(int amount)
    {

        if (progressSlider == null) return; // si no checkeo esto el juego se rompe al reintentar, porque unity guarda la referencia del slider que se ha destruido al volver a cargar la escena

        progressAmount += amount;
        progressSlider.value = progressAmount;

        if(progressAmount >= 100)
        {
            //level complete
            Debug.Log("acabo");
        }

        if(progressAmount < 0)
        {
            print("No mas pls");
            progressAmount = 0;
            contadorDerrota++;
        }

        if(contadorDerrota == 2)
        {
            Time.timeScale = 0f;

            GameObject tmpCanvas = GameObject.Find("UI");

            Instantiate(tryAgain, tmpCanvas.transform);

            print("PERDISTE");
        }
    }
}
