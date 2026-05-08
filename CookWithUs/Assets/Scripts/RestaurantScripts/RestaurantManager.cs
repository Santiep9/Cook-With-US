using UnityEngine;

public class RestaurantManager : MonoBehaviour
{
    public Areas areas;
    public DoorData doorData;

    public GameObject pirulinRestaurante;
    public GameObject mJohnRestaurante;
    public GameObject jusepRestaurante;

    public Transform player;
    public Transform restaurantDoor;

    private void Awake()
    {
        if (areas.pirulinCompleted || areas.mjohnCompleted || areas.jusepCompleted)
        {
            ResetAreaValues();
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
        areas.pirulinSelected = false;
        areas.mjohnSelected = false;
        areas.jusepSelected = false;

        doorData.puertaJusep = false;
        doorData.puertaMJohn = false;
        doorData.puertaRestaurante = false;
    }
}
