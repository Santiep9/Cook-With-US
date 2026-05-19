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

    public TMP_Text dialogueText, nameText;
    public Image portraitImage;
    public Image playerPortrait;

    private int dialogueIndex;
    private bool isTyping, isDialogueActive;

    private int voiceNumber;
    private Coroutine autoProgressCoroutine;

    private Vector3 npcOriginalScale;
    private Vector3 playerOriginalScale;

    private void Awake()
    {
        npcOriginalScale = portraitImage.transform.localScale;
        playerOriginalScale = playerPortrait.transform.localScale;
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

    void UpdateSpeakerVisuals()
    {
        bool npcSpeaking = true;

        if (dialogueData.isNPCSpeaking != null &&
            dialogueIndex < dialogueData.isNPCSpeaking.Length)
        {
            npcSpeaking = dialogueData.isNPCSpeaking[dialogueIndex];
        }

        if (npcSpeaking)
        {
            //NPC ACTIVO
            portraitImage.color = new Color(1f, 1f, 1f, 1f);
            portraitImage.transform.localScale = npcOriginalScale * 1.15f;

            //PLAYER INACTIVO
            playerPortrait.color = new Color(1f, 1f, 1f, 0.25f);
            playerPortrait.transform.localScale = playerOriginalScale * 0.85f;
        }
        else
        {
            //PLAYER ACTIVO
            playerPortrait.color = new Color(1f, 1f, 1f, 1f);
            playerPortrait.transform.localScale = playerOriginalScale * 1.15f;

            //NPC INACTIVO
            portraitImage.color = new Color(1f, 1f, 1f, 0.25f);
            portraitImage.transform.localScale = npcOriginalScale * 0.85f;
        }
    }

    IEnumerator TypeLine()
    {
        isTyping = true;
        dialogueText.SetText(string.Empty);

        UpdateSpeakerVisuals();

        AudioClip currentClip = dialogueData.voiceSound[dialogueIndex];

        SoundEffectManager.PlayVoice(currentClip); //VOICE ACTING

        foreach (char letter in dialogueData.dialogueLines[dialogueIndex])
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(dialogueData.typingSpeed);
        }

        isTyping = false;

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
            portraitImage.transform.localScale = npcOriginalScale;
            playerPortrait.transform.localScale = playerOriginalScale;

            portraitImage.color = Color.white;
            playerPortrait.color = Color.white;

            StopAllCoroutines();
            isDialogueActive = false;
            dialogueText.SetText(string.Empty);
            dialoguePanel.SetActive(false);
            PauseController.SetPause(false);
            if (dialogueData.primeraConverLibro)
            {
                dialogueData.primeraConverLibro = false;

                RestaurantManager.Instance?.UpdateBooks();
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
