using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    int progressAmount;
    public Slider progressSlider;
    public int contadorDerrota = 0;
    public GameObject tryAgain;

    public Image handleSprite;

    public Sprite[] heartSprites;

    public Areas areas;
    private void Start()
    {

        progressAmount = 0;
        progressSlider.value = 0;
        Botones.OnPointsAdded += IncreaseProgressAmount;
    }
    public void IncreaseProgressAmount(int amount)
    {

        if (progressSlider == null) return; // si no checkeo esto el juego se rompe al reintentar, porque unity guarda la referencia del slider que se ha destruido al volver a cargar la escena

        progressAmount += amount;
        progressSlider.value = progressAmount;

        if(progressAmount >= 100)
        {
            areas.pirulinCompleted = true;
            SceneManager.LoadScene("Restaurant");
            Debug.Log("acabo");
        }

        if(progressAmount < 0)
        {
            print("No mas pls");
            progressAmount = 0;
            contadorDerrota++;
        }
        else
        {
            contadorDerrota = 0;
        }

        if (contadorDerrota == 2)
        {
            Time.timeScale = 0f;

            GameObject tmpCanvas = GameObject.Find("UI");

            Instantiate(tryAgain, tmpCanvas.transform);

            print("PERDISTE");
        }



        UpdateSprite();
    }

    void UpdateSprite()
    {
        if (handleSprite == null) return;

        int index = Mathf.Clamp(contadorDerrota, 0, heartSprites.Length - 1);
        handleSprite.sprite = heartSprites[index];
    }
}
