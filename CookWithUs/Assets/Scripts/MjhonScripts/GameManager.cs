using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;
using Unity.VisualScripting;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] public Button Object1;
    [SerializeField] public Button Object2;
    [SerializeField] public Button Object3;
    [SerializeField] public Button Object4;
    [SerializeField] public Button Object5;
    [SerializeField] public Button Object6;
    [SerializeField] public Button Object7;
    [SerializeField] public TextMeshProUGUI Text;
    
    List<string> ObjectNames1 = new List<string>() { "Concha1", "Raqueta1", "TV1", "Sexo1" };
    List<string> ObjectNames2 = new List<string>() { "Concha2", "Raqueta2", "TV2", "Sexo2" };
    List<string> ObjectNames3 = new List<string>() { "Concha3", "Raqueta3", "TV3", "Sexo3" };
    List<string> ObjectNames4 = new List<string>() { "Concha4", "Raqueta4", "TV4", "Sexo4" };
    List<string> ObjectNames5 = new List<string>() { "Concha5", "Raqueta5", "TV5", "Sexo5" };
    List<string> ObjectNames6 = new List<string>() { "Concha6", "Raqueta6", "TV6", "Sexo6" };
    List<string> ObjectNames7 = new List<string>() { "Concha7", "Raqueta7", "TV7", "Sexo7" };
    List<string> ObjectNames8 = new List<string>() { "Concha8", "Raqueta8", "TV8", "Sexo8" };


    enum Player
    {
        John,
        John2,
        John3,
        John4,
        John5,
        John6,
        John7,
        John8

    }

    Player current_player = Player.John;

    void Start()
    {
        Text.enabled = false;
        Listener(Object1, Object2, Object3, Object4, Object5, Object6, Object7);
        ShowButton(Object1, Object2, Object3, Object4, Object5, Object6, Object7);


    }

    private void ObjectClicked(Button objectpass)
    {

        switch (objectpass.name)
        {

            case "Concha":
                Debug.Log("Object 1 clicked");
                TextDisplayer(0);
                HideButton(Object1, Object2, Object3, Object4, Object5, Object6, Object7);
                break;
            case "Raqueta":
                Debug.Log("Object 2 clicked");
                TextDisplayer(1);
                HideButton(Object1, Object2, Object3, Object4, Object5, Object6, Object7);
                break;
            case "TV":
                Debug.Log("Object 3 clicked");
                TextDisplayer(2);
                HideButton(Object1, Object2, Object3, Object4, Object5, Object6, Object7);
                break;
            case "Sexo":
                Debug.Log("Object 4 clicked");
                TextDisplayer(3);
                HideButton(Object1, Object2, Object3, Object4, Object5, Object6, Object7);
                break;
            case "Paso":
                Debug.Log("Object 5 clicked");
                ShowButton(Object1, Object2, Object3, Object4, Object5, Object6, Object7);
                break;
            case "Derecha":
                if (current_player < Player.John8)
                {
                    current_player = current_player + 1;
                }
                break;
            case "Izquierda":
                if (current_player > 0)
                {
                    current_player = current_player - 1;
                }   
                break;
            default:
                Debug.Log("Unknown object clicked");
                break;
        }

    }

    void Update()
    {



    }
    // texto = jhon_list[buton_n]
    void TextDisplayer(int button_n)
    {
        if (Object1 != null) Object1.interactable = false;
        if (Object2 != null) Object2.interactable = false;
        if (Object3 != null) Object3.interactable = false;
        if (Object4 != null) Object4.interactable = false;

        switch (current_player)
        {
            case Player.John:
                Text.enabled = true;
                Text.text = ObjectNames1[button_n];
                break;
            case Player.John2:
                Text.enabled = true;
                Text.text = ObjectNames2[button_n];
                break;
            case Player.John3:
                Text.enabled = true;
                Text.text = ObjectNames3[button_n];
                break;
            case Player.John4:
                Text.enabled = true;
                Text.text = ObjectNames4[button_n];
                break;
            case Player.John5:
                Text.enabled = true;
                Text.text = ObjectNames5[button_n];
                break;
            case Player.John6:
                Text.enabled = true;
                Text.text = ObjectNames6[button_n];
                break;
            case Player.John7:
                Text.enabled = true;
                Text.text = ObjectNames7[button_n];
                break;
            case Player.John8:
                Text.enabled = true;
                Text.text = ObjectNames8[button_n];
                break;


        }
    }
    private void HideButton(Button btn, Button btn2, Button btn3, Button btn4, Button btn5, Button btn6, Button btn7)
    {
        if (btn == null) return;
        if (btn2 == null) return;
        if (btn3 == null) return;
        if (btn4 == null) return;
        if (btn5 == null) return;
        if (btn6 == null) return;
        if (btn7 == null) return;
        // ocultar botones principales y dejar el botón "Paso" visible
        btn.gameObject.SetActive(false);
        btn2.gameObject.SetActive(false);
        btn3.gameObject.SetActive(false);
        btn4.gameObject.SetActive(false);
        // asegurar que el botón paso esté activo e interactuable
        btn5.gameObject.SetActive(true);
        btn5.interactable = true;
        btn6.gameObject.SetActive(false);
        btn7.gameObject.SetActive(false);
     
    }
    private void ShowButton(Button btn, Button btn2, Button btn3, Button btn4, Button btn5, Button btn6, Button btn7)
    {
        if (btn == null) return;
        if (btn2 == null) return;
        if (btn3 == null) return;
        if (btn4 == null) return;
        if (btn5 == null) return;
        if (btn6 == null) return;
        if (btn7 == null) return;
        // volver a registrar listeners de forma segura (eliminar duplicados)
        Listener(btn, btn2, btn3, btn4, btn5, btn6, btn7);
        // mostrar y hacer interactuables los botones principales
        btn.gameObject.SetActive(true);
        btn.interactable = true;
        btn2.gameObject.SetActive(true);
        btn2.interactable = true;
        btn3.gameObject.SetActive(true);
        btn3.interactable = true;
        btn4.gameObject.SetActive(true);
        btn4.interactable = true;
        btn5.gameObject.SetActive(false);
        btn5.interactable = false;
        btn6.gameObject.SetActive(true);
        btn6.interactable = true;
        btn7.gameObject.SetActive(true);
        btn7.interactable = true;
    }
    private void Listener(Button uno, Button dos, Button tres, Button cuatro, Button cinco , Button seis, Button siete)
    {
        if (uno == null) return;
        if (dos == null) return;
        if (tres == null) return;
        if (cuatro == null) return;
        if (cinco == null) return;
        Text.enabled = false;

        // Eliminar listeners previos para evitar múltiples registros
        uno.onClick.RemoveAllListeners();
        dos.onClick.RemoveAllListeners();
        tres.onClick.RemoveAllListeners();
        cuatro.onClick.RemoveAllListeners();
        cinco.onClick.RemoveAllListeners();
        seis.onClick.RemoveAllListeners();
        siete.onClick.RemoveAllListeners();

        uno.onClick.AddListener(() => ObjectClicked(uno));
        dos.onClick.AddListener(() => ObjectClicked(dos));
        tres.onClick.AddListener(() => ObjectClicked(tres));
        cuatro.onClick.AddListener(() => ObjectClicked(cuatro));
        cinco.onClick.AddListener(() => ObjectClicked(cinco));
        seis.onClick.AddListener(() => ObjectClicked(seis));
        siete.onClick.AddListener(() => ObjectClicked(siete));
    }
}