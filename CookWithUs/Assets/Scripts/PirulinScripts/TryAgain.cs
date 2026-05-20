using UnityEngine;
using UnityEngine.SceneManagement;

public class TryAgain : MonoBehaviour
{
    public void TryAgainGame()
    {
        SoundEffectManager.StopMusic();
        SceneManager.LoadScene("Pirulin MiniGame");
    }
}
