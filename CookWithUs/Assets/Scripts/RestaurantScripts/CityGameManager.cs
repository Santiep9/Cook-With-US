using UnityEngine;

public class CityGameManager : MonoBehaviour
{
    public static CityGameManager Instance;

    public int activeScene = -1;

    public bool[] unlockedScenes = new bool[3];

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
