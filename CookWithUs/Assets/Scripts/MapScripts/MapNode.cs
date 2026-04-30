using UnityEngine;
using UnityEngine.UI;

public class MapNode : MonoBehaviour
{

    CityGameManager cityGameManager;

    public GameObject visualObject;
    public GameObject visualObject1;
    public GameObject visualObject2;

    

    

    void Start()
    {
        cityGameManager = FindFirstObjectByType<CityGameManager>();
        Debug.Log(cityGameManager);
        Check();
    }
    void Check()
    {
        if (cityGameManager.isClicked1)
        {
            SelectPirulin();
        }
        if (cityGameManager.isClicked2)
        {
            SelectMjohn();
        }
        if (cityGameManager.isClicked3)
        {
            SelectJusep();
        }
    }

    void SelectPirulin()
    {    
            visualObject.SetActive(true);      
    }
    void SelectMjohn()
    {
            visualObject1.SetActive(true);
    }
    void SelectJusep()
    {
            visualObject2.SetActive(true);
    }
}