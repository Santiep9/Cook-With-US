using UnityEngine;
using UnityEngine.SceneManagement;

public class BackRestaurant : MonoBehaviour
{
    public string sceneName = "Restaurant";

    void OnMouseDown()
    {
        SceneManager.LoadScene(sceneName);
    }
}
