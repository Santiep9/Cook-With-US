using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] public Button Object1;
    [SerializeField] public Button Object2;
    [SerializeField] public Button Object3;
    [SerializeField] public Button Object4;
    [SerializeField] public TextMeshProUGUI Text;

    List<string> ObjectNames1 = new List<string>() { "HOLA", "PUTA", "POKE", "UY" };
    List<string> ObjectNames2 = new List<string>() { "Object1", "Object2", "Object3", "Object4" };
    List<string> ObjectNames3 = new List<string>() { "Object1", "Object2", "Object3", "Object4" };
    List<string> ObjectNames4 = new List<string>() { "Object1", "Object2", "Object3", "Object4" };
    List<string> ObjectNames5 = new List<string>() { "Object1", "Object2", "Object3", "Object4" };
    List<string> ObjectNames6 = new List<string>() { "Object1", "Object2", "Object3", "Object4" };
    List<string> ObjectNames7 = new List<string>() { "Object1", "Object2", "Object3", "Object4" };
    List<string> ObjectNames8 = new List<string>() { "Object1", "Object2", "Object3", "Object4" };
   

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
        Object1.onClick.AddListener(() => ObjectClicked(Object1));
        Object2.onClick.AddListener(() => ObjectClicked(Object2));
        Object3.onClick.AddListener(() => ObjectClicked(Object3));
        Object4.onClick.AddListener(() => ObjectClicked(Object4));


    }

    private void ObjectClicked(Button objectpass)
    {

        switch (objectpass.name)
        {
            
            case "Concha":
                Debug.Log("Object 1 clicked");
                TextDisplayer(0);
                break;
            case "Raqueta":
                Debug.Log("Object 2 clicked");
                TextDisplayer(1);
                break;
            case "TV":
                Debug.Log("Object 3 clicked");
                TextDisplayer(2);
                break;
            case "Condon":
                Debug.Log("Object 4 clicked");
                TextDisplayer(3);
                break;
            default:
                Debug.Log("Unknown object clicked");
                break;
        }
        HideButton(Object1,Object2,Object3,Object4);
    }

    void Update()
    {
      
         
        
    }
    // texto = jhon_list[buton_n]
    void TextDisplayer (int button_n)
    {
        Object1.enabled = false;
        Object2.enabled = false;
        Object3.enabled = false;
        Object4.enabled = false;
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
    private void HideButton(Button btn,Button btn2, Button btn3, Button btn4)
    {
        if (btn == null) return;
        if (btn2 == null) return;
        if (btn3 == null) return;
        if (btn4 == null) return;
        btn.gameObject.SetActive(false);
        btn2.gameObject.SetActive(false);
        btn3.gameObject.SetActive(false);
        btn4.gameObject.SetActive(false);
    }
}
