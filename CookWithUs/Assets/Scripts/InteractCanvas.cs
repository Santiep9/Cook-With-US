using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class InteractCanvas : MonoBehaviour
{
    public GameObject bocadilloComic;
    public GameObject player;
    public GameObject CanvasDialogue;

    public Transform interactPoint;

    private bool closePlayer = false;

    private RectTransform interactRect;

    private void Start()
    {
        interactRect = bocadilloComic.GetComponent<RectTransform>();
    }

    void Update()
    {
        if(closePlayer)
        {
            interactRect.position = Camera.main.WorldToScreenPoint(interactPoint.position);
            
            if (Keyboard.current.eKey.wasPressedThisFrame)
            {
                bocadilloComic.SetActive(false);
                CanvasDialogue.SetActive(true);
                player.GetComponent<PlayerMove>().canMove = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            closePlayer = true;
            bocadilloComic.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            closePlayer = false;
            bocadilloComic.SetActive(false);
        }
    }

}
