using UnityEngine;

[CreateAssetMenu(fileName = "NPCDialogue", menuName = "Scriptable Objects/NPCDialogue")]
public class NPCDialogue : ScriptableObject
{
    public string npcName;
    public Sprite npcPortrait;
    public string[] dialogueLines;
    public bool[] autoProgressLines;
    public float autoProgressDelay = 1.5f;
    public float typingSpeed = 0.05f;
    public AudioClip[] voiceSound;
    public float voicePitch = 1f;

    public bool necesitaTimeline = false;
    public bool timelineTerminada = false;
    public bool timelineYminijuego = false;

    [Header("Dialogo Inicial Libro")]
    public bool playOnSceneStart;
    public bool hasPlayed;
}
