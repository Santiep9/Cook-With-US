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

    public CityGameManager cityGameManager;

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

    


    public void Start()
    {
        cityGameManager.GetComponent<CityGameManager>();
        CityGameManager.Instance.activeScene = -1;
    }

    public void SelectPirulin()
    {
        change(pirulin);
        CityGameManager.Instance.activeScene = 0;
        cityGameManager.isClicked1 = true;
        cityGameManager.isClicked2 = false;
        cityGameManager.isClicked3 = false;


    }

    public void SelectMjohn()
    {
        change(mjohn);
        CityGameManager.Instance.activeScene = 1;
        cityGameManager.isClicked1 = false;
        cityGameManager.isClicked2 = true;
        cityGameManager.isClicked3 = false;


    }

    public void SelectJusep()
    {
        change(jusep);
        CityGameManager.Instance.activeScene = 2;
        cityGameManager.isClicked3 = true;
        cityGameManager.isClicked2 = false;
        cityGameManager.isClicked1 = false;


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