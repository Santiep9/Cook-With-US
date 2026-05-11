using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    [SerializeField] Button[] Buttons;

    [SerializeField] Image[] Images;

    [SerializeField] Sprite[] Spris;

    [SerializeField] GameObject Canvas;
    [SerializeField] GameObject CanvasSeguro;

    [SerializeField] TextMeshProUGUI[] Texts;

    [SerializeField] Areas areas;

    int Object;
    int contador;
    int QueJohn;

    List<string> ObjectNames1 = new List<string>() { "En mi más humilde opinion, depiladas al 3 es la forma más óptima de generar placer para un homosapiens.", "Me es igual, es mejor Prince of Tennis.", "Bueno, se podría que me suelo adentrar por esos lares", "Por favor, soy todo un experto en la materia, una vez conocí a Thomas, y no fue para tranportarme." };
    List<string> ObjectNames2 = new List<string>() { "Eyyyyy hermano, cuanto mas grande mejor, depiladas al 3 molan mucho.", "Siiiii hermano, tenis es vida", "Quesesooo hermano, aunque me molan las extranjeras, las tias por supuestoo", "Con estaaa (se está señalado el paquete)" };
    List<string> ObjectNames3 = new List<string>() { "Buenos días, soy una persona horrible, ¿te refieres a la de mar?.", "¡PÁDEL! Menuda CALUMNIA! Como osas comparar un deporte, con tremenda BIRRIA.", "Pues mira, un poquito de Shingeki No Kyojin ahora mismo no me vendría mal, pero como se enteren mis amigos, adiós al club de tenis (es claramente un club homosexual)", "TSCH, hasta el matrimonio nada." };
    List<string> ObjectNames4 = new List<string>() { "*Hace sonidos de intento de almeja*", "...  Rafa Nadal es el goat tío.", "*Intenta contenerse para no volar su tapadera", "Personas 0, almejas 27" };

    List<string> Questions1 = new List<string>() { "¿Como te gustan las conchas?", "¿Te gusta Rafa Nadal?", "Tu tienes pinta de chaqueteartela con monas chinas.", "¿Sabes lo que es el coito?" };
    List<string> Questions2 = new List<string>() { "¿Ey wagwan, como te molan las conchitas?", "¿Te gusta el tenis?", "¿Tú tienes TV tío?", "¿Tu como le das a la zambomba?" };
    List<string> Questions3 = new List<string>() { "Buenas tardes, ¿sabe usted lo que es una concha?", "Tu seguro que le das al pádel.", "¿Bueno, de series que te gusta?", "¿Cuál es tu posición favorita?" };
    List<string> Questions4 = new List<string>() { "Como te gust- escuchame, que haces tío, veo a través de tu disfraz", "Oye esto es vergonzoso ya, sé que eres humano tío, bueno, te mola el tenis o algo.", "Salte ya del disfraz loco, que haces aquí, si me dices tu serie favorita te salvo va.", "¿Con cuantas PERSONAS HUMANAS has tenido coito?" };

    String[] Respuestas;
    enum Player
    {
        John,
        John2,
        John3,
        John4,
    }
    Player current_player = Player.John;

    void Start()
    {
        Texts[0].enabled = false; Texts[1].enabled = false; Texts[4].enabled = false; Texts[6].enabled = false; Texts[7].enabled = false;
        Listener(Buttons[0], Buttons[1], Buttons[2], Buttons[3], Buttons[4], Buttons[5], Buttons[6], Buttons[13], Buttons[15]);
        PasoListener(Buttons[7]);
        ShowButton(Buttons[0], Buttons[1], Buttons[2], Buttons[3], Buttons[4], Buttons[5], Buttons[6], Buttons[13], Buttons[15]);
        HidePaso(Buttons[7]);
        HideSuspect1(Buttons[8], Buttons[9], Buttons[10], Buttons[11]);   
    }
    void Update()
    {
        Texts[2].text = "Preguntas restantes: " + contador.ToString() + " /10";
        QueJohn = (int)current_player;
        Texts[3].text = "Meji:" + (QueJohn + 1).ToString();
        switch(current_player)
        {
            case Player.John:
                Images[2].sprite = Spris[0];
                break;
            case Player.John2:
                Images[2].sprite = Spris[1];
                break;
            case Player.John3:
                Images[2].sprite = Spris[2];
                break;
            case Player.John4:
                Images[2].sprite = Spris[3];
                break;
        }
     
    }   

    private void ObjectClicked(Button objectpass)
    {

        switch (objectpass.name)
        {
            case "Libreta":
                ShowCanvas(Canvas);
                break;
            case "Atras":
                HideCanvas(Canvas);
                break;
            case "Concha":
                QuestionTextDisplayer(0);
                HideButton(Buttons[0], Buttons[1], Buttons[2], Buttons[3], Buttons[4], Buttons[5], Buttons[6]);
                Object = 0;
                HideLibreta(Buttons[12]);
                contador++;
                break;
            case "Raqueta":
                QuestionTextDisplayer(1);
                HideButton(Buttons[0], Buttons[1], Buttons[2], Buttons[3], Buttons[4], Buttons[5], Buttons[6]);
                Object = 1;
                HideLibreta(Buttons[12]);
                contador++;
                break;
            case "TV":
                QuestionTextDisplayer(2);
                HideButton(Buttons[0], Buttons[1], Buttons[2], Buttons[3], Buttons[4], Buttons[5], Buttons[6]);
                Object = 2;
                HideLibreta(Buttons[12]);
                contador++;
                break;
            case "Sexo":
                QuestionTextDisplayer(3);
                HideButton(Buttons[0], Buttons[1], Buttons[2], Buttons[3], Buttons[4], Buttons[5], Buttons[6]);
                HideLibreta(Buttons[12]);
                Object = 3;
                contador++;
                break;
            case "Derecha":

                if (current_player < Player.John4)
                {
                    current_player = ++current_player;
                    Debug.Log("Current player: " + current_player);
                }
                break;
            case "Izquierda":
                if (current_player > 0)
                {
                    current_player = --current_player;
                }
                break;
            case "Paso":
                Texts[1].enabled = false;
                TextDisplayer(Object);
                HidePaso(Buttons[4]);
                ShowPaso(Buttons[7]);
                break;
            case "Paso1":
                if (contador >= 10)
                {
                    Images[1].gameObject.SetActive(false);
                    Texts[0].enabled = false;
                    Texts[2].enabled = false;              
                    Texts[3].enabled = false;
                    Texts[4].enabled = true;
                    Texts[5].enabled = false;
                    HidePaso(Buttons[4]);
                    HidePaso(Buttons[7]);
                    ShowSuspect1(Buttons[8], Buttons[9], Buttons[10], Buttons[11]);
                    SuspectListener(Buttons[8], Buttons[9], Buttons[10], Buttons[11]);
                    break;
                }
                ShowButton(Buttons[0], Buttons[1], Buttons[2], Buttons[3], Buttons[4], Buttons[5], Buttons[6], Buttons[13], Buttons[15]);
                ShowLibreta(Buttons[12]);
                Texts[0].enabled = false;
                HidePaso(Buttons[7]);
                break;
            case "Si":
                Images[1].gameObject.SetActive(false);
                Texts[0].enabled = false;               
                Texts[2].enabled = false;
                Texts[3].enabled = false;                
                Texts[4].enabled = true;
                Texts[5].enabled = false;
                HideCanvas(CanvasSeguro);
                HideButton(Buttons[0], Buttons[1], Buttons[2], Buttons[3], null, Buttons[5], Buttons[6]);
                HideLibreta(Buttons[14]);
                ShowSuspect1(Buttons[8], Buttons[9], Buttons[10], Buttons[11]);
                SuspectListener(Buttons[8], Buttons[9], Buttons[10], Buttons[11]);
                break;
            case "Retry":
                SceneManager.LoadScene("MJohn Minigame");
                break;
            case "Suspect 1":
                HideSuspect1(Buttons[8], Buttons[9], Buttons[10], Buttons[11]);
                Lose();
                break;
            case "Suspect 2":
                HideSuspect1(Buttons[8], Buttons[9], Buttons[10], Buttons[11]);
                Lose();
                break;
            case "Suspect 3":
                HideSuspect1(Buttons[8], Buttons[9], Buttons[10], Buttons[11]);
                Win();
                break;
            case "Suspect 4":
                HideSuspect1(Buttons[8], Buttons[9], Buttons[10], Buttons[11]);
                Lose();
                break;
            default:
                Debug.Log("Unknown object clicked");
                break;
        }

    }

    void QuestionTextDisplayer(int button_n)
    {
        Texts[1].enabled = true;
            switch (current_player)
            {
                case Player.John:
                Texts[1].text = Questions1[button_n];
                    break;
                case Player.John2:
                Texts[1].text = Questions2[button_n];
                    break;
                case Player.John3:
                Texts[1].text = Questions3[button_n];
                    break;
                case Player.John4:
                Texts[1].text = Questions4[button_n];
                    break;
            }
    }
    void TextDisplayer(int button_n)
    {

        switch (current_player)
        {
            case Player.John:
                Texts[0].enabled = true;
                Texts[0].text = ObjectNames1[button_n];
                Images[2].sprite = Spris[0];
                break;
            case Player.John2:
                Texts[0].enabled = true;
                Texts[0].text = ObjectNames2[button_n];
                Images[2].sprite = Spris[1];
                break;
            case Player.John3:
                Texts[0].enabled = true;
                Texts[0].text = ObjectNames3[button_n];
                Images[2].sprite = Spris[2];
                break;
            case Player.John4:
                Texts[0].enabled = true;
                Texts[0].text = ObjectNames4[button_n];
                Images[2].sprite = Spris[3];
                break;
        }
    }

    private void HideButton(Button btn, Button btn2, Button btn3, Button btn4, Button btn5, Button btn6, Button btn7)
    {

        btn.gameObject.SetActive(false);
        btn2.gameObject.SetActive(false);
        btn3.gameObject.SetActive(false);
        btn4.gameObject.SetActive(false);
        if (btn5 != null)
        {
            btn5.gameObject.SetActive(true);
            btn5.interactable = true;
        };
        btn6.gameObject.SetActive(false);
        btn7.gameObject.SetActive(false);
    }
    private void HideLibreta(Button libreta)
    {
        libreta.gameObject.SetActive(false);
    }
    private void ShowLibreta(Button libreta)
    {
        libreta.gameObject.SetActive(true);
        libreta.interactable = true;
    }
    public void ShowCanvas(GameObject canvas)
    {
        canvas.SetActive(true);
        Buttons[0].interactable = false;
        Buttons[1].interactable = false;
        Buttons[2].interactable = false;
        Buttons[3].interactable = false;
        Buttons[4].interactable = false;
        Buttons[5].interactable = false;
        Buttons[6].interactable = false;
    }
    public void HideCanvas(GameObject canvas)
    {
        canvas.SetActive(false);
        Buttons[0].interactable = true;
        Buttons[1].interactable = true;
        Buttons[2].interactable = true;
        Buttons[3].interactable = true;
        Buttons[4].interactable = true;
        Buttons[5].interactable = true;
        Buttons[6].interactable = true;
    }
    private void HideSuspect1(Button spc1, Button spc2 , Button spc3, Button spc4)
    {
        spc1.gameObject.SetActive(false);
        spc2.gameObject.SetActive(false);
        spc3.gameObject.SetActive(false);
        spc4.gameObject.SetActive(false);
    }

    private void ShowSuspect1(Button spc1, Button spc2, Button spc3, Button spc4)
    {
        spc1.gameObject.SetActive(true);
        spc1.interactable = true;
        spc2.gameObject.SetActive(true);
        spc2.interactable = true;
        spc3.gameObject.SetActive(true);
        spc3.interactable = true;
        spc4.gameObject.SetActive(true);
        spc4.interactable = true;
        Images[2].gameObject.SetActive(false);
    }


    private void ShowPaso(Button btn8)
    {
        if (btn8 == null) return;
        btn8.gameObject.SetActive(true);
        btn8.interactable = true;
        PasoListener(btn8);
    }
    private void HidePaso(Button btn8)
    {
        if (btn8 == null) return;
        btn8.gameObject.SetActive(false);
        btn8.interactable = false;
    }

    private void ShowButton(Button btn, Button btn2, Button btn3, Button btn4, Button btn5, Button btn6, Button btn7, Button btn8, Button btn9)
    {
        Listener(btn, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9);
       
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
    private void Listener(Button uno, Button dos, Button tres, Button cuatro, Button cinco , Button seis, Button siete, Button ocho, Button nueve)
    {
        Texts[1].enabled = false;

        // Eliminar listeners previos para evitar múltiples registros
        uno.onClick.RemoveAllListeners();
        dos.onClick.RemoveAllListeners();
        tres.onClick.RemoveAllListeners();
        cuatro.onClick.RemoveAllListeners();
        cinco.onClick.RemoveAllListeners();
        seis.onClick.RemoveAllListeners();
        siete.onClick.RemoveAllListeners();
        ocho.onClick.RemoveAllListeners();
        nueve.onClick.RemoveAllListeners();

        uno.onClick.AddListener(() => ObjectClicked(uno));
        dos.onClick.AddListener(() => ObjectClicked(dos));
        tres.onClick.AddListener(() => ObjectClicked(tres));
        cuatro.onClick.AddListener(() => ObjectClicked(cuatro));
        cinco.onClick.AddListener(() => ObjectClicked(cinco));
        seis.onClick.AddListener(() => ObjectClicked(seis));
        siete.onClick.AddListener(() => ObjectClicked(siete));
        ocho.onClick.AddListener(() => ObjectClicked(ocho));
        nueve.onClick.AddListener(() => ObjectClicked(nueve));
    }
    private void PasoListener(Button paso)
    {
        paso.onClick.RemoveAllListeners();
        paso.onClick.AddListener(() => ObjectClicked(paso));
    }
    private void SuspectListener(Button spc1, Button spc2, Button spc3, Button spc4)
    {
        spc1.onClick.RemoveAllListeners();
        spc2.onClick.RemoveAllListeners();
        spc3.onClick.RemoveAllListeners();
        spc4.onClick.RemoveAllListeners();
        spc1.onClick.AddListener(() => ObjectClicked(spc1));
        spc2.onClick.AddListener(() => ObjectClicked(spc2));
        spc3.onClick.AddListener(() => ObjectClicked(spc3));
        spc4.onClick.AddListener(() => ObjectClicked(spc4));
    }

    void Win()
    {
        HideLibreta(Buttons[12]);
        Images[0].gameObject.SetActive(false);
        areas.mjohnCompleted = true;
        Texts[4].enabled = false;
        Texts[6].enabled = true;
        HidePaso(Buttons[7]);
        HidePaso(Buttons[4]);
        SceneManager.LoadScene("Restaurant");
    }

    void Lose()
    {
        HideLibreta(Buttons[12]);
        Images[0].gameObject.SetActive(false);
        Texts[4].enabled = false;
        Texts[7].enabled = true;
        HidePaso(Buttons[7]);
        HidePaso(Buttons[4]);
        ShowLibreta(Buttons[15]);
    }
}
