using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class InteractBook : MonoBehaviour
{
    public GameObject interactText;
    public GameObject canvasBook;
    public GameObject player;

    private bool closePlayer = false;

    void Update()
    {
        if (closePlayer && Keyboard.current.eKey.wasPressedThisFrame)
        {
            canvasBook.SetActive(true);
            interactText.SetActive(false);
            player.GetComponent<PlayerMove>().canMove = false;
        }
    }

    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            closePlayer = true;
            interactText.SetActive(true);
        }
    }

    private void OnTriggerExit2D(UnityEngine.Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            closePlayer = false;
            interactText.SetActive(false);
        }
    }
}