using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;
using UnityEngine.SceneManagement;
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
    [SerializeField] public Button Object8;
    [SerializeField] public Button Suspect1;
    [SerializeField] public Button Suspect2;
    [SerializeField] public Button Suspect3;
    [SerializeField] public Button Suspect4;
    [SerializeField] public Button Suspect5;
    [SerializeField] public Button Suspect6;
    [SerializeField] public Button Suspect7;
    [SerializeField] public Button Suspect8;
    [SerializeField] public Button Libreta;

    [SerializeField] public Image Escritorio;
    [SerializeField] public Image QuestionsBox;
    [SerializeField] public Image JohnImage;

    [SerializeField] public Sprite John1S;
    [SerializeField] public Sprite John2S;
    [SerializeField] public Sprite John3S;
    [SerializeField] public Sprite John4S;
    [SerializeField] public Sprite John5S;
    [SerializeField] public Sprite John6S;
    [SerializeField] public Sprite John7S;
    [SerializeField] public Sprite John8S;

    [SerializeField] public GameObject Canvas;


    [SerializeField] public TextMeshProUGUI Text;
    [SerializeField] public TextMeshProUGUI QuestionText;
    [SerializeField] public TextMeshProUGUI Contador;
    [SerializeField] public TextMeshProUGUI John;
    [SerializeField] public TextMeshProUGUI SuspectText;
    [SerializeField] public TextMeshProUGUI BoxText;
    [SerializeField] public TextMeshProUGUI FinalText;
    [SerializeField] public TextMeshProUGUI BadFinalText;

    

    [SerializeField] public Areas areas;

    int Object;
    int contador;
    int QueJohn;

    List<string> ObjectNames1 = new List<string>() { "En mi más humilde opinion, depiladas al 3 es la forma más óptima de generar placer para un homosapiens.", "Me es igual, es mejor Prince of Tennis.", "Bueno, se podría que me suelo adentrar por esos lares", "Por favor, soy todo un experto en la materia, una vez conocí a Thomas, y no fue para tranportarme." };
    List<string> ObjectNames2 = new List<string>() { "Eyyyyy hermano, cuanto mas grande mejor, depiladas al 3 molan mucho.", "Siiiii hermano, tenis es vida", "Quesesooo hermano, aunque me molan las extranjeras, las tias por supuestoo", "Con estaaa (se está señalado el paquete)" };
    List<string> ObjectNames3 = new List<string>() { "Buenos días, soy una persona horrible, ¿te refieres a la de mar?.", "¡PÁDEL! Menuda CALUMNIA! Como osas comparar un deporte, con tremenda BIRRIA.", "Pues mira, un poquito de Shingeki No Kyojin ahora mismo no me vendría mal, pero como se enteren mis amigos, adiós al club de tenis (es claramente un club homosexual)", "TSCH, hasta el matrimonio nada." };
    List<string> ObjectNames4 = new List<string>() { "*Hace sonidos de intento de almeja*", "...  Rafa Nadal es el goat tío.", "*Intenta contenerse para no volar su tapadera", "Personas 0, almejas 27" };
    List<string> ObjectNames5 = new List<string>() { "COMO! Manager! Este tío me está diciendo cosas inapropiadas.            Con pelo. ", "No.", "No, me he visto absolutamente todas", "Una vez me hicieron un tren" };
    List<string> ObjectNames6 = new List<string>() { "EL LINCE, DEPILADITA AL 3 TU SABE'", "El unico teni que yo conosco son esto pedaso de teni que traigo encima, miralo de Naik original", "A mi lo dibujito eso chino me ponen bien emperrao asi chinao tu sabe con la goma bien bacana", "Mi loco tu ere bien machista, la mujere son para repetar y amar no para profanar, eso es cosa del LUCIFEL MI LOCO!" };
    List<string> ObjectNames7 = new List<string>() { "La belleza reside en el interior, tus comentarios no me afectan, sin embargo, depiladas con diseño de autor.", "Un saque de tenis es arte, obviamente no estoy al nivel de hacer un saque bello, AÚN. De eso trata la vida, my friend.", "No me interesaría formar parte de un elenco de reparto televisivo, son seres superficiales. El verdadero arte reside en el país del sol naciente, Nippon, como lo llaman ahí. El anime es magnifico.", "Tienes razón, no he tocado a nadie, la única doncella que se atrevió a entrar en mi dominio se terminó espantando. Pues me pidio verme desnudo, y tonto de mí le enseñé la desnudez de mi alma, pues ella pedía la desnudez de mi cuerpo. También hice un tren una vez." };
    List<string> ObjectNames8 = new List<string>() { "Concha8, Concha8, Concha8, Concha8, Concha8, Concha8, Concha8, Concha8, Concha8, Concha8... ", "La verdad que Rafa Nadal le da duro, RAQUETA7 RAQUETA7 RAQUETA7 AHHGFHFDGHGFHG", "LAS SERIES LAS SERIES LAS SERIES AYUDAAAAAA *se ha puesto a llorar*", "LO SABIA, LO SABIA HAY GENTE EN MIS PAREDES, HAY GENTE EN MIS PAREDES, EN MIS PAREDEEEEEES." };

    List<string> Questions1 = new List<string>() { "¿Como te gustan las conchas?", "¿Te gusta Rafa Nadal?", "Tu tienes pinta de chaqueteartela con monas chinas.", "¿Sabes lo que es el coito?" };
    List<string> Questions2 = new List<string>() { "¿Ey wagwan, como te molan las conchitas?", "¿Te gusta el tenis?", "¿Tú tienes TV tío?", "¿Tu como le das a la zambomba?" };
    List<string> Questions3 = new List<string>() { "Buenas tardes, ¿sabe usted lo que es una concha?", "Tu seguro que le das al pádel.", "¿Bueno, de series que te gusta?", "¿Cuál es tu posición favorita?" };
    List<string> Questions4 = new List<string>() { "Como te gust- escuchame, que haces tío, veo a través de tu disfraz", "Oye esto es vergonzoso ya, sé que eres humano tío, bueno, te mola el tenis o algo.", "Salte ya del disfraz loco, que haces aquí, si me dices tu serie favorita te salvo va.", "¿Con cuantas PERSONAS HUMANAS has tenido coito?" };
    List<string> Questions5 = new List<string>() { "¿Hostia, a ti te gustan las conchas?", "¿Te gusta el tenis?", "¿Eres feliz con tu vida, si es así cuantas temporadas de Grey's Anatomy te has visto.?", "¿Tienes sexo de vez en cuando?" };
    List<string> Questions6 = new List<string>() { "¿Oye mi loco, a ti las conchitas como te gustan?", "¿El teni mi tigre como te va?", "¿Tu usas mucho la television, el hueso?", "¿Cuantas gatitas tu te bajas en un finde?" };
    List<string> Questions7 = new List<string>() { "¿Hostia tio, te iba a preguntar sobre conchas pero es que eres tan feo que no puedo.", "Eres más feo que fallar un saque", "Te pagarían por NO salir en una serie tío, así de feo eres loco.", "¿Tu no has tocado a nadie en tu vida verdad?" };
    List<string> Questions8 = new List<string>() { "¿Estás bien tío, que te pasa?", "¿Oye tío necesitas ayuda, te mola algún deporte, rollo el tenis o algo?", "¿Tío dime algo va, que series te molan?", "He estado en tus paredes todo este tiempo, ¿no has follado con nadie verdad?" };

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
    enum Sprites
    {
        John1S,
        John2S,
        John3S,
        John4S,
        John5S,
        John6S,
        John7S,
        John8S
    }

    Player current_player = Player.John;

    void Start()
    {
        Text.enabled = false;
        QuestionText.enabled = false;
        BadFinalText.enabled = false;
        FinalText.enabled = false;
        Listener(Object1, Object2, Object3, Object4, Object5, Object6, Object7);
        PasoListener(Object8);
        ShowButton(Object1, Object2, Object3, Object4, Object5, Object6, Object7);
        HidePaso(Object8);
        HideSuspect1(Suspect1, Suspect2, Suspect3, Suspect4);
        HideSuspect2(Suspect5, Suspect6, Suspect7, Suspect8);     
        SuspectText.enabled = false;
    }
    void Update()
    {
        Contador.text = "Preguntas restantes: " + contador.ToString() + " /16";
        QueJohn = (int)current_player;
        John.text = "John:" + (QueJohn + 1).ToString();
        switch(current_player)
        {
            case Player.John:
                JohnImage.sprite = John1S;
                break;
            case Player.John2:
                JohnImage.sprite = John2S;
                break;
            case Player.John3:
                JohnImage.sprite = John3S;
                break;
            case Player.John4:
                JohnImage.sprite = John4S;
                break;
            case Player.John5:
                JohnImage.sprite = John5S;
                break;
            case Player.John6:
                JohnImage.sprite = John6S;
                break;
            case Player.John7:
                JohnImage.sprite = John7S;
                break;
            case Player.John8:
                JohnImage.sprite = John8S;
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
                HideButton(Object1, Object2, Object3, Object4, Object5, Object6, Object7);
                Object = 0;
                HideLibreta(Libreta);
                contador++;
                break;
            case "Raqueta":
                QuestionTextDisplayer(1);
                HideButton(Object1, Object2, Object3, Object4, Object5, Object6, Object7);
                Object = 1;
                HideLibreta(Libreta);
                contador++;
                break;
            case "TV":
                QuestionTextDisplayer(2);
                HideButton(Object1, Object2, Object3, Object4, Object5, Object6, Object7);
                Object = 2;
                HideLibreta(Libreta);
                contador++;
                break;
            case "Sexo":
                QuestionTextDisplayer(3);
                HideButton(Object1, Object2, Object3, Object4, Object5, Object6, Object7);
                HideLibreta(Libreta);
                Object = 3;
                contador++;
                break;
            case "Derecha":

                if (current_player < Player.John8)
                {
                    current_player = current_player + 1;
                    Debug.Log("Current player: " + current_player);
                }
                break;
            case "Izquierda":
                if (current_player > 0)
                {
                    current_player = current_player - 1;
                }
                break;
            case "Paso":
                QuestionText.enabled = false;
                TextDisplayer(Object);
                ShowPaso(Object8);
                break;
            case "Paso1":
                if (contador >= 16)
                {
                    Escritorio.gameObject.SetActive(false);
                    QuestionsBox.gameObject.SetActive(false);
                    BoxText.enabled = false;
                    Contador.enabled = false;
                    John.enabled = false;
                    Text.enabled = false;
                    SuspectText.enabled = true;
                    HidePaso(Object8);
                    HidePaso1(Object5);
                    HideLibreta(Libreta);
                    ShowSuspect1(Suspect1, Suspect2, Suspect3, Suspect4);
                    ShowSuspect2(Suspect5, Suspect6, Suspect7, Suspect8);
                    SuspectListener(Suspect1, Suspect2, Suspect3, Suspect4, Suspect5, Suspect6, Suspect7, Suspect8);
                    break;
                }
                ShowButton(Object1, Object2, Object3, Object4, Object5, Object6, Object7);
                ShowLibreta(Libreta);
                QuestionText.enabled = false;
                HidePaso(Object8);
                
                break;
            case "Suspect 1":
                HideSuspect1(Suspect1, Suspect2, Suspect3, Suspect4);
                HideSuspect2(Suspect5, Suspect6, Suspect7, Suspect8);
                Win();
                break;
            case "Suspect 2":
                HideSuspect1(Suspect1, Suspect2, Suspect3, Suspect4);
                HideSuspect2(Suspect5, Suspect6, Suspect7, Suspect8);
                Lose();
                break;
            case "Suspect 3":
                HideSuspect1(Suspect1, Suspect2, Suspect3, Suspect4);
                HideSuspect2(Suspect5, Suspect6, Suspect7, Suspect8);
                Lose();
                break;
            case "Suspect 4":
                HideSuspect1(Suspect1, Suspect2, Suspect3, Suspect4);
                HideSuspect2(Suspect5, Suspect6, Suspect7, Suspect8);
                Lose();
                break;
            case "Suspect 5":
                HideSuspect1(Suspect1, Suspect2, Suspect3, Suspect4);
                HideSuspect2(Suspect5, Suspect6, Suspect7, Suspect8);
                Lose();
                break;
            case "Suspect 6":
                HideSuspect1(Suspect1, Suspect2, Suspect3, Suspect4);
                HideSuspect2(Suspect5, Suspect6, Suspect7, Suspect8);
                Lose();
                break;
            case "Suspect 7":
                HideSuspect1(Suspect1, Suspect2, Suspect3, Suspect4);
                HideSuspect2(Suspect5, Suspect6, Suspect7, Suspect8);
                Lose();
                break;
            case "Suspect 8":             
                HideSuspect1(Suspect1, Suspect2, Suspect3, Suspect4);
                HideSuspect2(Suspect5, Suspect6, Suspect7, Suspect8);
                Lose();
                break;
            default:
                Debug.Log("Unknown object clicked");
                break;
        }

    }

    void QuestionTextDisplayer(int button_n)
    {
        if (Object1 != null) Object1.interactable = false;
        if (Object2 != null) Object2.interactable = false;
        if (Object3 != null) Object3.interactable = false;
        if (Object4 != null) Object4.interactable = false;

            QuestionText.enabled = true;
            switch (current_player)
            {
                case Player.John:
                    QuestionText.text = Questions1[button_n];
                    break;
                case Player.John2:
                    QuestionText.text = Questions2[button_n];
                    break;
                case Player.John3:
                    QuestionText.text = Questions3[button_n];
                    break;
                case Player.John4:
                    QuestionText.text = Questions4[button_n];
                    break;
                case Player.John5:
                    QuestionText.text = Questions5[button_n];
                    break;
                case Player.John6:
                    QuestionText.text = Questions6[button_n];
                    break;
                case Player.John7:
                    QuestionText.text = Questions7[button_n];
                    break;
                case Player.John8:
                    QuestionText.text = Questions8[button_n];
                    break;
            }
    }
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
                JohnImage.sprite = John1S;
                break;
            case Player.John2:
                Text.enabled = true;
                Text.text = ObjectNames2[button_n];
                JohnImage.sprite = John2S;
                break;
            case Player.John3:
                Text.enabled = true;
                Text.text = ObjectNames3[button_n];
                JohnImage.sprite = John3S;
                break;
            case Player.John4:
                Text.enabled = true;
                Text.text = ObjectNames4[button_n];
                JohnImage.sprite = John4S;
                break;
            case Player.John5:
                Text.enabled = true;
                Text.text = ObjectNames5[button_n];
                JohnImage.sprite = John5S;
                break;
            case Player.John6:
                Text.enabled = true;
                Text.text = ObjectNames6[button_n];
                JohnImage.sprite = John6S;
                break;
            case Player.John7:
                Text.enabled = true;
                Text.text = ObjectNames7[button_n];
                JohnImage.sprite = John7S;
                break;
            case Player.John8:
                Text.enabled = true;
                Text.text = ObjectNames8[button_n];
                JohnImage.sprite = John8S;
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
        Object1.interactable = false;
        Object2.interactable = false;
        Object3.interactable = false;
        Object4.interactable = false;
        Object5.interactable = false;
        Object6.interactable = false;
        Object7.interactable = false;
    }
    public void HideCanvas(GameObject canvas)
    {
        canvas.SetActive(false);
        Object1.interactable = true;
        Object2.interactable = true;
        Object3.interactable = true;
        Object4.interactable = true;
        Object5.interactable = true;
        Object6.interactable = true;
        Object7.interactable = true;
    }
    private void HideSuspect1(Button spc1, Button spc2 , Button spc3, Button spc4)
    {
        if (spc1 == null) return;
        if (spc2 == null) return;
        if (spc3 == null) return;
        if (spc4 == null) return;
        spc1.gameObject.SetActive(false);
        spc2.gameObject.SetActive(false);
        spc3.gameObject.SetActive(false);
        spc4.gameObject.SetActive(false);
    }
    private void HideSuspect2(Button spc1, Button spc2, Button spc3, Button spc4)
    {
        if (spc1 == null) return;
        if (spc2 == null) return;
        if (spc3 == null) return;
        if (spc4 == null) return;
        spc1.gameObject.SetActive(false);
        spc2.gameObject.SetActive(false);
        spc3.gameObject.SetActive(false);
        spc4.gameObject.SetActive(false);
    }
    private void ShowSuspect1(Button spc1, Button spc2, Button spc3, Button spc4)
    {
        if (spc1 == null) return;
        if (spc2 == null) return;
        if (spc3 == null) return;
        if (spc4 == null) return;
        spc1.gameObject.SetActive(true);
        spc1.interactable = true;
        spc2.gameObject.SetActive(true);
        spc2.interactable = true;
        spc3.gameObject.SetActive(true);
        spc3.interactable = true;
        spc4.gameObject.SetActive(true);
        spc4.interactable = true;
        JohnImage.gameObject.SetActive(false);
    }
    private void ShowSuspect2(Button spc1, Button spc2, Button spc3, Button spc4)
    {
        if (spc1 == null) return;
        if (spc2 == null) return;
        if (spc3 == null) return;
        if (spc4 == null) return;
        spc1.gameObject.SetActive(true);
        spc1.interactable = true;
        spc2.gameObject.SetActive(true);
        spc2.interactable = true;
        spc3.gameObject.SetActive(true);
        spc3.interactable = true;
        spc4.gameObject.SetActive(true);
        spc4.interactable = true;
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
    private void HidePaso1(Button btn8)
    {
        if (btn8 == null) return;
        btn8.gameObject.SetActive(false);
        btn8.interactable = false;
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
    private void PasoListener(Button paso)
    {
        if (paso == null) return;

        paso.onClick.RemoveAllListeners();
        paso.onClick.AddListener(() => ObjectClicked(paso));
    }
    private void SuspectListener(Button spc1, Button spc2, Button spc3, Button spc4, Button spc5, Button spc6, Button spc7, Button spc8)
    {
        if (spc1 == null) return;
        if (spc2 == null) return;
        if (spc3 == null) return;
        if (spc4 == null) return;
        if (spc5 == null) return;
        if (spc6 == null) return;
        if (spc7 == null) return;
        if (spc8 == null) return;
        spc1.onClick.RemoveAllListeners();
        spc2.onClick.RemoveAllListeners();
        spc3.onClick.RemoveAllListeners();
        spc4.onClick.RemoveAllListeners();
        spc5.onClick.RemoveAllListeners();
        spc6.onClick.RemoveAllListeners();
        spc7.onClick.RemoveAllListeners();
        spc8.onClick.RemoveAllListeners();
        spc1.onClick.AddListener(() => ObjectClicked(spc1));
        spc2.onClick.AddListener(() => ObjectClicked(spc2));
        spc3.onClick.AddListener(() => ObjectClicked(spc3));
        spc4.onClick.AddListener(() => ObjectClicked(spc4));
        spc5.onClick.AddListener(() => ObjectClicked(spc5));
        spc6.onClick.AddListener(() => ObjectClicked(spc6));
        spc7.onClick.AddListener(() => ObjectClicked(spc7));
        spc8.onClick.AddListener(() => ObjectClicked(spc8));
    }

    void Win()
    {
        areas.mjohnCompleted = true;
        SuspectText.enabled = false;
        FinalText.enabled = true;
        HidePaso(Object8);
        HidePaso1(Object5);
        SceneManager.LoadScene("Restaurant");
    }

    void Lose()
    {
        SuspectText.enabled = false;
        BadFinalText.enabled = true;
        HidePaso(Object8);
        HidePaso1(Object5);
    }
}
