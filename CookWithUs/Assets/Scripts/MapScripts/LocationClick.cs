using UnityEngine;
using UnityEngine.SceneManagement;

public class LocationClick : MonoBehaviour
{
    public int sceneId;
    public string sceneName;

    void OnMouseDown()
    {
        bool unlocked = CityGameManager.Instance.unlockedScenes[sceneId];
        bool active = CityGameManager.Instance.activeScene == sceneId;

        if (unlocked || active)
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.Log("Escena bloqueada");
        }
    }
}
