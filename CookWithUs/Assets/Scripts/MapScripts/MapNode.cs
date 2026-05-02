using UnityEngine;
using UnityEngine.UI;

public class MapNode : MonoBehaviour
{

    public Areas areas;
    public DoorData doorData;

    public GameObject visualObject;
    public GameObject visualObject1;
    public GameObject visualObject2;
    
    public Transform player;

    public Transform jusepDoor;
    public Transform mjohnDoor;
    
    void Start()
    {
        CheckCharacter();
        CheckPOS();
    }

    void CheckPOS()
    {
        if (doorData.puertaJusep)
        {
            player.transform.position = jusepDoor.position;
        }
        if (doorData.puertaMJohn)
        {
            player.transform.position = mjohnDoor.position;
        }
    }

    void CheckCharacter()
    {
        if (areas.pirulinSelected)
        {
            SelectPirulin();
        }
        if (areas.mjohnSelected || areas.mjohnCompleted)
        {
            SelectMjohn();
        }
        if (areas.jusepSelected || areas.jusepCompleted)
        {
            SelectJusep();
        }
    }

    void SelectPirulin()
    {    
        if(!areas.pirulinCompleted) visualObject.SetActive(true);
        else visualObject.SetActive(false);
    }
    void SelectMjohn()
    {
         visualObject1.SetActive(false);
    }
    void SelectJusep()
    {
         visualObject2.SetActive(false);
    }
}