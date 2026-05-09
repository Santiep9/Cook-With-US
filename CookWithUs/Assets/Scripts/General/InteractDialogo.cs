using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InteractDialogo : MonoBehaviour
{
    PlayerInput input;
    public NPCDialogue dialogueData;

    public GameObject dialoguePanel;
    public GameObject Timeline;
    public GameObject bocadilloComic;

    public GameObject player;
    private bool closePlayer = false;

    public Transform interactPoint;
    private RectTransform interactRect;

    public TMP_Text dialogueText, nameText;
    public Image portraitImage;

    private int dialogueIndex;
    private bool isTyping, isDialogueActive;

    public bool conversacionTerminada = false;
    public GameObject terminaConver;

    private int voiceNumber;
    private void Start()
    {
        interactRect = bocadilloComic.GetComponent<RectTransform>();
        terminaConver.SetActive(false);
        input = player.GetComponent<PlayerInput>();
    }

    void Update()
    {
        if (!closePlayer) return;

        interactRect.position = Camera.main.WorldToScreenPoint(interactPoint.position);

        if (input.actions["Interact"].WasPressedThisFrame())
        {
            if(conversacionTerminada)
            {
                if( Timeline != null)
                {
                    Timeline.SetActive(true);
                }

                dialoguePanel.SetActive(false);
            }
            if (isDialogueActive)
            {
                NextLine();
            }
            else
            {
                StartDialogue();
            }
        }
    }

    void StartDialogue()
    {
        isDialogueActive = true;

        bocadilloComic.SetActive(false);

        dialogueIndex = 0;

        nameText.SetText(dialogueData.npcName);
        portraitImage.sprite = dialogueData.npcPortrait;

        dialoguePanel.SetActive(true);
        player.GetComponent<PlayerMove>().canMove = false;

        StartCoroutine(TypeLine());
    }

    void NextLine()
    {
        SoundEffectManager.StopVoice(); //PARA EL VOICE ACTING SI SE PULSA ANTES DE QUE TERMINE DE ESCRIBIR

        if (isTyping)
        {
            StopAllCoroutines();
            dialogueText.SetText(dialogueData.dialogueLines[dialogueIndex]);
            voiceNumber++;
            isTyping = false;

            if (dialogueIndex >= dialogueData.dialogueLines.Length - 1)
            {
                conversacionTerminada = true;
                terminaConver.SetActive(true);
            }
        }
        else if(++dialogueIndex < dialogueData.dialogueLines.Length)
        {
            //si hay otra linea, escribe la siguiente 
            StartCoroutine(TypeLine());
        }
        else
        {
            EndDialogue();
        }
    }

    IEnumerator TypeLine()
    {
        isTyping = true;
        dialogueText.SetText(string.Empty);

        AudioClip currentClip = dialogueData.voiceSound[dialogueIndex];

        SoundEffectManager.PlayVoice(currentClip); //VOICE ACTING

        foreach (char letter in dialogueData.dialogueLines[dialogueIndex])
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(dialogueData.typingSpeed);
        }

        isTyping = false;

        if(dialogueIndex >= dialogueData.dialogueLines.Length - 1)
        {
            conversacionTerminada = true;
            terminaConver.SetActive(true);
        }

        if (dialogueData.autoProgressLines.Length > dialogueIndex && dialogueData.autoProgressLines[dialogueIndex])
        {
            yield return new WaitForSeconds(currentClip.length);
            NextLine();
        }
    }

    public void EndDialogue()
    {
        StopAllCoroutines();
        isDialogueActive = false;
        dialogueText.SetText(string.Empty);
        dialoguePanel.SetActive(false);
        player.GetComponent<PlayerMove>().canMove = true;
        input.SwitchCurrentActionMap("Player");
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
