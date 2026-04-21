using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class JusepInteract : MonoBehaviour
{
    public GameObject interactText;
    public GameObject player;

    private bool closePlayer = false;

    void Update()
    {
        if (closePlayer && Keyboard.current.eKey.wasPressedThisFrame)
        {
            interactText.SetActive(false);
            SceneManager.LoadScene("Jusep Minigame");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            closePlayer = true;
            interactText.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            closePlayer = false;
            interactText.SetActive(false);
        }
    }
}
