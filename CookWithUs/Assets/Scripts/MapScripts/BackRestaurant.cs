using UnityEngine;
using UnityEngine.SceneManagement;

public class BackRestaurant : MonoBehaviour
{
    public string sceneName = "Restaurant";

    void OnMouseDown()
    {
        Debug.Log("Click detectado");
        SceneManager.LoadScene(sceneName);
    }
}
