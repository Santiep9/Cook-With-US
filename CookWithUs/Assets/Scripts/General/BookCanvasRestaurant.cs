using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class BookCanvasRestaurant : MonoBehaviour, IInteractable
{
    public bool isCanvasActive { get; private set; }
    public GameObject canvas;
    public Areas areas;

    public Canvas LibroConversacion;

    public Image ingredientImg;
    public Image mapaImg;
    public TMP_Text ingredientTitle;
    public TMP_Text ingredientDesc;

    [System.Serializable]
    public class Option
    {
        public Sprite image;
        public string textTitle;
        public string textDesc;
    }

    [System.Serializable]
    public class OptionMapa
    {
        public Sprite image;
    }

    public Option pirulin;
    public Option mjohn;
    public Option jusep;

    public OptionMapa mapaPirulin;
    public OptionMapa mapaJusep;
    public OptionMapa mapaMJohn;

    public bool CanInteract()
    {
        return !isCanvasActive;
    }

    public void Interact()
    {
        if (!CanInteract()) return;

        if (areas.pirulinCompleted && areas.mjohnCompleted && areas.jusepCompleted)
        {
            FinalJuego();
            return;
        }
        canvas.SetActive(true);
        isCanvasActive = true;
        PauseController.SetPause(true);
    }

    public void SelectPirulin()
    {
        change(pirulin);
        changeMap(mapaPirulin);
        areas.pirulinSelected = true;
        areas.mjohnSelected = false;
        areas.jusepSelected = false;
    }

    public void SelectMjohn()
    {
        change(mjohn);
        changeMap(mapaMJohn);
        areas.mjohnSelected = true;
        areas.pirulinSelected = false;
        areas.jusepSelected = false;
    }

    public void SelectJusep()
    {
        change(jusep);
        changeMap(mapaJusep);
        areas.jusepSelected = true;
        areas.mjohnSelected = false;
        areas.pirulinSelected = false;
    }

    public void CloseBook()
    {
        canvas.SetActive(false);
        isCanvasActive = false;
        PauseController.SetPause(false);
    }

    void change(Option opcion)
    {
        ingredientImg.sprite = opcion.image;
        ingredientTitle.text = opcion.textTitle;
        ingredientDesc.text = opcion.textDesc;
    }

    void changeMap(OptionMapa option)
    {
        mapaImg.sprite = option.image;
    }

    void FinalJuego()
    {
        LibroConversacion.gameObject.SetActive(true);
    }
}