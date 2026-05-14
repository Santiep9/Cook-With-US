using UnityEngine;

public class RestaurantManager : MonoBehaviour
{
    public Areas areas;
    public DoorData doorData;

    public GameObject pirulinRestaurante;
    public GameObject mJohnRestaurante;
    public GameObject jusepRestaurante;

    public GameObject libroInicial;
    public GameObject libroFinal;

    public Transform player;
    public Transform restaurantDoor;

    private void Awake()
    {
        if (areas.pirulinCompleted || areas.mjohnCompleted || areas.jusepCompleted)
        {
            ResetAreaValues();
        }

        if(areas.pirulinCompleted && areas.mjohnCompleted && areas.jusepCompleted)
        {
            libroInicial.SetActive(false);
            libroFinal.SetActive(true);
        }

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
}
