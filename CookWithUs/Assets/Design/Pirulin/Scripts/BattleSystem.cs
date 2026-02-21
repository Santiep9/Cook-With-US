using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerLocation;
    public Transform enemyLocation;

    public TMP_Text dialogueText;

    public BattleState state;

    [Header("Opciones para elegir")]
    public GameObject boton1;
    public GameObject boton2;
    public GameObject boton3;
    public TMP_Text texto1;
    public TMP_Text texto2;
    public TMP_Text texto3;
    public Transform botonSpawn;

    private void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
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

       
        GameObject nuevoBoton = Instantiate(boton1, botonSpawn);

       
        RectTransform rt = nuevoBoton.GetComponent<RectTransform>();
        rt.SetParent(botonSpawn, false);  

       
        rt.anchoredPosition = Vector2.zero; 
        rt.sizeDelta = new Vector2(200, 50);

        //TMP_Text textoHijo = boton1.transform.GetChild(0).GetComponent<TMP_Text>();
        //opcion1.text = "Eres guapo.";
    }
}
