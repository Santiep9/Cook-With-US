using EasyTransition;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Rendering;
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

    [SerializeField] AudioClip[] QuestionAudios;
    [SerializeField] AudioClip[] AnswerAudios;
    [SerializeField] AudioClip[] VFX;

    [SerializeField] Areas areas;

    public TransitionSettings fadeTransition;

    int Object;
    int contador;
    int QueJohn;

    List<string> ObjectNames1 = new List<string>() { "Buenas tardes, solo conozco a una Conchi y la desahucié hace unos 3 años. ", "No conozco a ningún Shohei ni a ningún Tani, no me gusta el baseball soy más de la hípica. ", "Pues mira, un poquito de Shingeki No Kyojin ahora mismo no me vendría mal, pero como se enteren mis amigos, adiós al club de PATRIA UNIDA", "Atelier Ayesha: The Alchemist Of Dusk, JUEGAZO. " };
    List<string> ObjectNames2 = new List<string>() { "Mano mira esto yo tenia una tia llamada Conchi, una latima’ que se fue pal guevaso tu me entiende’. REST IN PEACE mi tiita Conchi RIP 4EVER IN MY HEART. ", "DIIIIIIABLO 77 COMO NO VOY A CONOSEL’ AL DIOSITO OHTANI, ESE HOMBRE NACIÓ PARA JUGAR BEISBOL, EL DIAAAAAAAABLO. ", "El diiiiiiiablo a mi la vaina esa de lo dibujito’ chinos me ponen bien emperrao’ asi chinao’ tu sabe, son bien bacanos MAMAGUEVO. ", "Te voy a ser honesto papi a mi esa vaina no me va mucho, yo soy más de ponerme peluche y salir a bellaquear tu sabe’. " };
    List<string> ObjectNames3 = new List<string>() { "Sí, si mis cálculos no son erróneos tengo aproximadamente un miembro familiar llamado Conchi, más exactamente mi tía. ", "Tus deducciones han sido incorrectas pequeño padawan, pues el baseball me encanta, más concretamente el jugador Shohei Ohtani, ese tío lo tiene todo. ", "NO SE LLAMAN MONAS CHINAS. Son mis waifu, un respeto. Y si, se podría decir que me suelo adentrar por esos lares, mi serie favorita es Boku no Pico. ", "872, pero conozco mi potencial y sé que puedo llegar mucho más lejos, no me subestimes chaval, te puede salir muy caro. Si alguna vez empiezas una pelea conmigo y ves que me empiezo a reír, huye.  " };
    List<string> ObjectNames4 = new List<string>() { "*Hace sonidos de intento de almeja*", "...  Ohtani es el goat tío.", "*Intenta contenerse para no volar su tapadera*", "*sonidos de asfixiándose con el disfraz* " };

    List<string> Questions1 = new List<string>() { "Buenas tardes, ¿conoce usted a una señora llamada “Conchi”? ", "¿Conoces al jugador de baseball llamado Shohei Ohtani? ", "Bueno, a ti te gustan las series? ", "Sé sincero, cuál es tu videojuego favorito, si es que tienes uno porque con esas pintas… " };
    List<string> Questions2 = new List<string>() { "KLK mi hermano cómo estás ¿Te suena de algo el nombre Conchi? ", "¿Mi tigre tu sabes quien es ese tal Shohei Ohtani? ", "¿Cuéntame papi a ti como te gustan las series de televisión? ", "¿De videojuegos a ti que te gusta? " };
    List<string> Questions3 = new List<string>() { "Ey tío, ¿conoces a alguna Conchi? ", "No sé ni para que te pregunto porque … bueno no pareces el más fan de salir de casa, pero ¿te gusta algún deporte? ¿Quizás el baseball? ", "Tu tienes pinta de chaqueteartela con las series esas de monas chinas. ", "Cuántos videojuegos te has platinado, sé sincero. " };
    List<string> Questions4 = new List<string>() { "Conoces algun- escuchame, que haces tío, veo a través de tu disfraz", "Oye esto es vergonzoso ya, sé que eres humano tío, bueno, te mola el baseball o algo.", "Salte ya del disfraz loco, que haces aquí, si me dices tu serie favorita te salvo va.", "Salte ya tío, 30 añitos tiene la criaturita. Además se te ve cara de sufrimiento ahí dentro eh. " };

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
        Texts[0].enabled = false; Texts[1].enabled = false; Texts[4].enabled = false; Texts[6].enabled = false; Texts[7].enabled = false; // bucle for para esto
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
                StopAllCoroutines();
                SoundEffectManager.StopVoice();
                Texts[1].enabled = false;
                TextDisplayer(Object);
                HidePaso(Buttons[4]);
                ShowPaso(Buttons[7]);
                break;
            case "Paso1":
                if (contador >= 10)
                {
                    StopAllCoroutines();
                    SoundEffectManager.StopVoice();
                    Images[1].gameObject.SetActive(false);
                    Texts[0].enabled = false;
                    Texts[2].enabled = false;              
                    Texts[3].enabled = false;
                    Texts[4].enabled = true;
                    Texts[5].enabled = false;
                    Texts[8].enabled = true;
                    HidePaso(Buttons[4]);
                    HidePaso(Buttons[7]);
                    ShowSuspect1(Buttons[8], Buttons[9], Buttons[10], Buttons[11]);
                    ShowLibreta(Buttons[12]);
                    HideLibreta(Buttons[14]);
                    SuspectListener(Buttons[8], Buttons[9], Buttons[10], Buttons[11]);
                    break;
                }
                StopAllCoroutines();
                Texts[0].text = "";
                Texts[1].text = "";
                SoundEffectManager.StopVoice();
                ShowButton(Buttons[0], Buttons[1], Buttons[2], Buttons[3], Buttons[4], Buttons[5], Buttons[6], Buttons[13], Buttons[15]);
                ShowLibreta(Buttons[12]);
                Texts[0].enabled = false;
                Texts[8].enabled = true;
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
                SoundEffectManager.StopVoice();
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
        Texts[8].enabled = false;

        switch (current_player)
            {
                case Player.John:
                StartCoroutine(TypeLine(Questions1[button_n], Texts[1]));
                AudioClip audioToPlay = QuestionAudios[button_n];
                Debug.Log(button_n + (int)current_player);
                SoundEffectManager.PlayVoice(audioToPlay);
                break;
                case Player.John2:
                StartCoroutine(TypeLine(Questions2[button_n], Texts[1]));
                AudioClip audioToPlay1 = QuestionAudios[button_n + 4];
                Debug.Log(button_n + 3);
                SoundEffectManager.PlayVoice(audioToPlay1);
                    break;
                case Player.John3:
                StartCoroutine(TypeLine(Questions3[button_n], Texts[1]));
                AudioClip audioToPlay2 = QuestionAudios[button_n + 8];
                Debug.Log(button_n + 7);
                SoundEffectManager.PlayVoice(audioToPlay2);
                    break;
                case Player.John4:
                StartCoroutine(TypeLine(Questions4[button_n], Texts[1]));
                AudioClip audioToPlay3 = QuestionAudios[button_n + 12];
                Debug.Log(button_n + 11);
                SoundEffectManager.PlayVoice(audioToPlay3);
                    break;
            }
    }

    void TextDisplayer(int button_n)
    {

        switch (current_player)
        {
            case Player.John:
                Texts[0].enabled = true;
                StartCoroutine(TypeLine(ObjectNames1[button_n], Texts[0]));
                Images[2].sprite = Spris[0];
                AudioClip audioToPlay = AnswerAudios[button_n];
                SoundEffectManager.PlayVoice(audioToPlay);
                break;
            case Player.John2:
                Texts[0].enabled = true;
                StartCoroutine(TypeLine(ObjectNames2[button_n], Texts[0]));
                Images[2].sprite = Spris[1];
                AudioClip audioToPlay1 = AnswerAudios[button_n + 4];
                SoundEffectManager.PlayVoice(audioToPlay1);
                break;
            case Player.John3:
                Texts[0].enabled = true;
                StartCoroutine(TypeLine(ObjectNames3[button_n], Texts[0]));
                Images[2].sprite = Spris[2];
                AudioClip audioToPlay2 = AnswerAudios[button_n + 8];
                SoundEffectManager.PlayVoice(audioToPlay2);
                break;
            case Player.John4:
                Texts[0].enabled = true;
                StartCoroutine(TypeLine(ObjectNames4[button_n], Texts[0]));
                Images[2].sprite = Spris[3];
                AudioClip audioToPlay3 = AnswerAudios[button_n + 12];
                SoundEffectManager.PlayVoice(audioToPlay3);
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
        Buttons[14].interactable = false;        
        if (Buttons[8] != null)
        {
            Buttons[8].interactable = false;
            Buttons[9].interactable = false;
            Buttons[10].interactable = false;
            Buttons[11].interactable = false;
        }
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
        Buttons[14].interactable = true;
        if (Buttons[8] != null)
        {
            Buttons[8].interactable = true;
            Buttons[9].interactable = true;
            Buttons[10].interactable = true;
            Buttons[11].interactable = true;
        }
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
    private void Listener(Button uno, Button dos, Button tres, Button cuatro, Button cinco , Button seis, Button siete, Button ocho, Button nueve) //array
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
        Texts[8].enabled = false;
        HidePaso(Buttons[7]);
        HidePaso(Buttons[4]);
        StartCoroutine(Wait());
        
    }

    void Lose()
    {
        AudioClip Lost = VFX[1];
        SoundEffectManager.PlayVoice(Lost);
        HideLibreta(Buttons[12]);
        Images[0].gameObject.SetActive(false);
        Texts[4].enabled = false;
        Texts[7].enabled = true;
        Texts[8].enabled = false;
        HidePaso(Buttons[7]);
        HidePaso(Buttons[4]);
        ShowLibreta(Buttons[15]);
    }

    IEnumerator Wait()
    {
        AudioClip Won = VFX[0];
        SoundEffectManager.PlayVoice(Won);

        yield return new WaitForSecondsRealtime(2f);

        TransitionManager.Instance().Transition("Restaurant", fadeTransition, 0);
    }
    IEnumerator TypeLine(string textin, TextMeshProUGUI Texton)
    {
        foreach (char letter in textin)
        {
            Texton.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
