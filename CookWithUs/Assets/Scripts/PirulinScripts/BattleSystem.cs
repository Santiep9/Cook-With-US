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

    [SerializeField] private Vector2 posicionYBoton;

    [Header("Opciones para elegir")]
    [SerializeField] private GameObject boton1;
    [SerializeField] private GameObject boton2;
    [SerializeField] private TMP_Text texto1;
    [SerializeField] private TMP_Text texto2;
    [SerializeField] private TMP_Text texto3;
    [SerializeField] private Transform botonSpawn;

    public List<GameObject> botones = new List<GameObject>();


    private void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
        posicionYBoton = new Vector2(0, 8);
    }

    IEnumerator SetupBattle()
    {
        //Instantiate(playerPrefab, playerLocation); esto para el juego final, cuando entras al minijuego instancia los characters
        //Instantiate(enemyPrefab, enemyLocation);

        dialogueText.text = "Bienvenido pequeñin.";

        yield return new WaitForSeconds(3f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    void PlayerTurn()
    {
        dialogueText.text = "Soy tan feo, nadie me querrá nunca...";

        CreateButtonCorrect(1);
        CreateButtonWrong(2);
    }
    void CreateButtonCorrect(int cantidad)
    {
        GameObject tmpCanvas = GameObject.Find("UI");
        RectTransform rect = tmpCanvas.GetComponent<RectTransform>();

        for (int i = 0; i < cantidad; i++)
        {
            GameObject nuevoBoton = Instantiate(boton1, tmpCanvas.transform);
            
            botones.Add(nuevoBoton);

            RandomizarBotones(nuevoBoton);

            RectTransform rt = nuevoBoton.GetComponent<RectTransform>();

            rt.anchoredPosition = posBoton1.anchoredPosition;

            TMP_Text textoHijo = nuevoBoton.transform.GetChild(0).GetComponent<TMP_Text>();
            textoHijo.text = "Eres guapo.";

            print("llamada CORRECT numero " + i);
        }
    }
    void CreateButtonWrong(int cantidad)
    {
        GameObject tmpCanvas = GameObject.Find("UI");
        RectTransform rect = tmpCanvas.GetComponent<RectTransform>();

        RectTransform[] posiciones = {posBoton2, posBoton3};

        for (int i = 0; i < cantidad; i++)
        {
            GameObject nuevoBoton = Instantiate(boton2, tmpCanvas.transform);

            botones.Add(nuevoBoton);

            RandomizarBotones(nuevoBoton);

            RectTransform rt = nuevoBoton.GetComponent<RectTransform>();

            rt.anchoredPosition = posiciones[i].anchoredPosition;

            TMP_Text textoHijo = nuevoBoton.transform.GetChild(0).GetComponent<TMP_Text>();
            textoHijo.text = "Eres guapo.";

            print("llamada WRONG numero " + i);
        }
    }

    void RandomizarBotones(GameObject boton)
    {
        for(int i = 0; i < botones.Count; i++)
        {
            int r = (int)(Random.value * (botones.Count - i));
            boton = botones[r];
            botones[r] = botones[i];
            botones[i] = boton;
            print(r + "numero random");
        }
    }
}
