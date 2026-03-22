using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BookCanvas : MonoBehaviour
{
    public Image ingredientImg;
    public TMP_Text ingredientTitle;
    public TMP_Text ingredientDesc;

    public GameObject canvasBook;
    public GameObject player;
    public GameObject interactText;

    [System.Serializable]
    public class Option
    {
        public Sprite image;
        public string textTitle;
        public string textDesc;
    }

    public Option pirulin;
    public Option mjohn;
    public Option jusep;

    public void SelectPirulin()
    {
        change(pirulin);
    }

    public void SelectMjohn()
    {
        change(mjohn);
    }

    public void SelectJusep()
    {
        change(jusep);
    }

    public void CloseBook()
    {
        canvasBook.SetActive(false);
        interactText.SetActive(true);
        player.GetComponent<PlayerMove>().canMove = true;
    }

    void change(Option opcion)
    {
        ingredientImg.sprite = opcion.image;
        ingredientTitle.text = opcion.textTitle;
        ingredientDesc.text = opcion.textDesc;
    }
}