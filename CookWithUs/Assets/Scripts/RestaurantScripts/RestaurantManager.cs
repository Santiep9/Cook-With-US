using UnityEngine;

public class RestaurantManager : MonoBehaviour
{
    public Areas areas;
    public DoorData doorData;
    public NPCDialogue dialogueData;

    public GameObject pirulinRestaurante;
    public GameObject mJohnRestaurante;
    public GameObject jusepRestaurante;

    public GameObject libroCanvas;
    public GameObject libroFinal;
    public GameObject libroInicial;

    public Transform player;
    public Transform restaurantDoor;

    public static RestaurantManager Instance;

    private void Awake()
    {
        Instance = this;

        if (areas.pirulinCompleted || areas.mjohnCompleted || areas.jusepCompleted)
        {
            ResetAreaValues();
        }

        UpdateBooks();

        if(areas.pirulinCompleted)
        {
            pirulinRestaurante.SetActive(true);
        }

        if(areas.mjohnCompleted)
        {
            mJohnRestaurante.SetActive(true);
        }

        if(areas.jusepCompleted)
        {
            jusepRestaurante.SetActive(true);
        }

        if(doorData.puertaRestaurante)
        {
            player.transform.position = restaurantDoor.position;
        }
    }

    void ResetAreaValues()
    {
        PauseController.SetPause(false);

        areas.pirulinSelected = false;
        areas.mjohnSelected = false;
        areas.jusepSelected = false;

        doorData.puertaJusep = false;
        doorData.puertaMJohn = false;
        doorData.puertaRestaurante = false;
    }

    public void UpdateBooks()
    {
        libroInicial.SetActive(false);
        libroCanvas.SetActive(false);
        libroFinal.SetActive(false);

        if (areas.pirulinCompleted && areas.mjohnCompleted && areas.jusepCompleted)
        {
            libroFinal.SetActive(true);
            return;
        }

        if (dialogueData.primeraConverLibro)
        {
            libroInicial.SetActive(true);
        }
        else
        {
            libroCanvas.SetActive(true);
        }
    }
}
