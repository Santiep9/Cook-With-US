using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject enemyPrefab;

    [SerializeField] private Transform playerLocation;
    [SerializeField] private Transform enemyLocation;

    [SerializeField] private RectTransform posBoton1;
    [SerializeField] private RectTransform posBoton2;
    [SerializeField] private RectTransform posBoton3;

    [SerializeField] private TMP_Text dialogueText;

    [SerializeField] private BattleState state;

    [Header("Opciones para elegir")]
    [SerializeField] private GameObject boton1;
    [SerializeField] private GameObject boton2;


    public List<GameObject> botones = new List<GameObject>();

    public RectTransform[] posiciones;

    public DialogueManager dialogueManager;

    public BattleState currentState => state;

    public bool DIALOGOCORRECT = false;

    public int contadorTEXTO = 0;


    private void Start()
    {
        Time.timeScale = 1.0f;
        dialogueManager = FindFirstObjectByType<DialogueManager>();

        state = BattleState.START;
        StartCoroutine(SetupBattle());


        posiciones = new RectTransform[] { posBoton1, posBoton2, posBoton3 };
    }

    IEnumerator SetupBattle()
    {
        //Instantiate(playerPrefab, playerLocation); esto para el juego final, cuando entras al minijuego instancia los characters
        //Instantiate(enemyPrefab, enemyLocation);

        dialogueText.text = "hola pequeñin";

        yield return new WaitForSeconds(3f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    void PlayerTurn()
    {
        dialogueText.text = dialogueManager.DialogueText();

        //CleanupButtons();
        CreateButtons();
        RandomizarBotones();
        AsignarPosiciones();
    }
    void CreateButtons()
    {
        contadorTEXTO = 1;
        GameObject tmpCanvas = GameObject.Find("UI");

        GameObject nuevoBotonBUENO = Instantiate(boton1, tmpCanvas.transform);

        botones.Add(nuevoBotonBUENO);

        TMP_Text textoHijo = nuevoBotonBUENO.transform.GetChild(0).GetComponent<TMP_Text>();
        textoHijo.text = dialogueManager.DialogueTextAnto();


        for (int i = 0; i < 2; i++)
        {
            contadorTEXTO++;

            GameObject nuevoBotonMALO = Instantiate(boton2, tmpCanvas.transform);

            botones.Add(nuevoBotonMALO);

            TMP_Text textoHijoMALO = nuevoBotonMALO.transform.GetChild(0).GetComponent<TMP_Text>();
            textoHijoMALO.text = dialogueManager.DialogueTextAnto();
        }

    }
    void RandomizarBotones()
    {
        for (int i = botones.Count - 1; i > 0; i--) // i 2 , r 0 // i 1, r 1
        {
            int r = Random.Range(0, i + 1);
            GameObject boton = botones[r];
            botones[r] = botones[i];
            botones[i] = boton;
        }
    }
    void AsignarPosiciones()
    {
        for (int i = 0; i < botones.Count; i++)
        {
            RectTransform rt = botones[i].GetComponent<RectTransform>();
            rt.anchoredPosition = posiciones[i].anchoredPosition;
        }
    }

    void CleanupButtons()
    {
        foreach (GameObject boton in botones)
        {
            Destroy(boton);
        }

        botones.Clear();
    }
    public void ElegirRespuesta(bool isCorrect)
    {
        if (isCorrect)
        {
            print("es buena BATTLE SYSTEM");
            DIALOGOCORRECT = true;
        }
        else
        {
            print("es mala BATTLE SYSTEM");
            DIALOGOCORRECT = false;
        }

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn(isCorrect));
    }

    IEnumerator EnemyTurn(bool isCorrect)
    {

        CleanupButtons();

        if (isCorrect)
        {
            dialogueText.text = dialogueManager.DialogueText();
        }
        else
        {
            dialogueText.text = dialogueManager.DialogueText();
        }

        yield return new WaitForSeconds(5f);


        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }
}
