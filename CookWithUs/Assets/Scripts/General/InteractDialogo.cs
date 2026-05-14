using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InteractDialogo : MonoBehaviour, IInteractable
{
    public NPCDialogue dialogueData;

    public GameObject dialoguePanel;
    public GameObject Timeline;
    //public GameObject bocadilloComic;

    //public Transform interactPoint;
    //private RectTransform interactRect;

    public TMP_Text dialogueText, nameText;
    public Image portraitImage;

    private int dialogueIndex;
    private bool isTyping, isDialogueActive;

    private int voiceNumber;
    private Coroutine autoProgressCoroutine;

    public bool necesitaMinijuego = false;
    public string NombreEscena;

    private void Start()
    {
        //interactRect = bocadilloComic.GetComponent<RectTransform>();
    }

    void Update()
    {
        //interactRect.position = Camera.main.WorldToScreenPoint(interactPoint.position);

        /*if (input.actions["Interact"].WasPressedThisFrame())
        {
            if (isDialogueActive)
            {
                NextLine();
            }
            else
            {
                StartDialogue();
            }
        }*/
    }
    public void Interact()
    {
        if (dialogueData == null || (PauseController.IsGamePaused && !isDialogueActive))
        {
            return;
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

    public bool CanInteract()
    {
        return !isDialogueActive;
    }

    void StartDialogue()
    {
        isDialogueActive = true;

        //bocadilloComic.SetActive(false);

        dialogueIndex = 0;

        nameText.SetText(dialogueData.npcName);
        portraitImage.sprite = dialogueData.npcPortrait;

        dialoguePanel.SetActive(true);
        PauseController.SetPause(true);

        StartCoroutine(TypeLine());
    }

    void NextLine()
    {
        if (autoProgressCoroutine != null)
        {
            StopCoroutine(autoProgressCoroutine);
            autoProgressCoroutine = null;
        }

        SoundEffectManager.StopVoice(); //PARA EL VOICE ACTING SI SE PULSA ANTES DE QUE TERMINE DE ESCRIBIR

        if (isTyping)
        {
            StopAllCoroutines();
            dialogueText.SetText(dialogueData.dialogueLines[dialogueIndex]);
            voiceNumber++;
            isTyping = false;

            /*if (dialogueIndex >= dialogueData.dialogueLines.Length - 1)
            {
                dialogueData.necesitaTimeline = true;
            }*/
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

        /*if(dialogueIndex >= dialogueData.dialogueLines.Length - 1)
        {
            dialogueData.conversacionTerminada = true;
        }*/

        if (dialogueData.autoProgressLines.Length > dialogueIndex && dialogueData.autoProgressLines[dialogueIndex])
        {
            autoProgressCoroutine = StartCoroutine(AutoProgress(currentClip.length));
        }
    }

    public void EndDialogue()
    {
        if(dialogueData.necesitaTimeline)
        {
            StartCoroutine(WaitForTimeline());
        }
        else
        {
            if(necesitaMinijuego)
            {
                SceneManager.LoadScene(NombreEscena);
            }
            else
            {
                StopAllCoroutines();
                isDialogueActive = false;
                dialogueText.SetText(string.Empty);
                dialoguePanel.SetActive(false);
                PauseController.SetPause(false);
            }
                
        }
    }

    IEnumerator WaitForTimeline()
    {
        Timeline.SetActive(true);

        yield return new WaitUntil(() => dialogueData.timelineTerminada);

        dialogueData.necesitaTimeline = false;
        StopAllCoroutines();
        isDialogueActive = false;
        dialogueText.SetText(string.Empty);
        dialoguePanel.SetActive(false);
        PauseController.SetPause(false);
    }

    IEnumerator AutoProgress(float delay)
    {
        yield return new WaitForSeconds(delay);

        NextLine();
    }
}
