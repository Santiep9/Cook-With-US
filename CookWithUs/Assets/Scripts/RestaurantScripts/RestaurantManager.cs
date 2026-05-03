using UnityEngine;

public class RestaurantManager : MonoBehaviour
{
    public Areas areas;
    public DoorData doorData;

    public GameObject pirulinRestaurante;
    public GameObject mJohnRestaurante;
    public GameObject jusepRestaurante;

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
    }

    void ResetAreaValues()
    {
        areas.pirulinSelected = false;
        areas.mjohnSelected = false;
        areas.jusepSelected = false;

        doorData.puertaJusep = false;
        doorData.puertaMJohn = false;
        doorData.puertaRestaurante = false;

        //falta logica para que si le damos new game o lo que sea los completed se hagan falsos
    }
}
