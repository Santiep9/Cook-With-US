using UnityEngine;

public class CityGameManager : MonoBehaviour
{
    public static CityGameManager Instance;

    public bool isClicked1;
    public bool isClicked2;
    public bool isClicked3;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
