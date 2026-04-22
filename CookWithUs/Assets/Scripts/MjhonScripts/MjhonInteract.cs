using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MjhonInteract : MonoBehaviour
{
    public GameObject interactText;
    public GameObject player;
    public GameObject CanvasDialogue;
    

    private bool closePlayer = false;

    void Update()
    {
        if (closePlayer && Keyboard.current.eKey.wasPressedThisFrame)
        {
            interactText.SetActive(false);
            CanvasDialogue.SetActive(true);
            player.GetComponent<PlayerMove>().canMove = false;
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
