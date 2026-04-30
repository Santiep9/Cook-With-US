using UnityEngine;

public class CityGameManager : MonoBehaviour
{
    public static CityGameManager Instance;

    BookCanvas bookCanvas;

    public int activeScene = -1;

    public bool[] unlockedScenes = new bool[3];

    public bool isClicked1;
    public bool isClicked2;
    public bool isClicked3;

    private void Start()
    {
        bookCanvas = GetComponent<BookCanvas>();
    }


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
