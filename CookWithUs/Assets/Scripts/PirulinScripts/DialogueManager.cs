using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{

    public string[] frasesPirulin = new string[12];
    public string[] respuestasPirulin = new string[24];
    public string[] opcionesAnto = new string[36];

    private BattleSystem bs;

    public List<int> valoresRandom = new List<int>();

    private int i = 0;

    private void Start()
    {
        bs = FindFirstObjectByType<BattleSystem>();
    }
    public string DialogueText()
    {
        if (bs == null) return "BS not found";

        string resultado = "";

        switch (bs.currentState)
        {
            case BattleState.PLAYERTURN:

                if (valoresRandom.Count >= 12)
                {
                    valoresRandom.Clear();
                    i = 0;
                }

                int randomValue = GetUniqueRandomIndex(0, 12);
                valoresRandom.Add(randomValue);

                resultado = frasesPirulin[valoresRandom[i]];

                break;

            case BattleState.ENEMYTURN:
                if (bs.DIALOGOCORRECT)
                {
                    print("ES BUENO");
                    resultado = respuestasPirulin[valoresRandom[i] * 2];

                    i++;
                    break;
                }
                print("ES MALO");
                resultado = respuestasPirulin[valoresRandom[i] * 2 + 1];

                i++;
                break;
        }

        return resultado;
    }

    public string DialogueTextAnto()
    {
        if (bs == null) return "BS not found";

        string resultado = "";

        switch (bs.currentState)
        {
            case BattleState.PLAYERTURN:
                if(bs.contadorTEXTO == 1)
                {
                    resultado = opcionesAnto[valoresRandom[i] * 3];
                }
                else if(bs.contadorTEXTO == 2)
                {
                    resultado = opcionesAnto[valoresRandom[i] * 3 + 1];
                }
                else
                {
                    resultado = opcionesAnto[valoresRandom[i] * 3 + 2];
                }

                    break;
        }

        return resultado;
    }

    int GetUniqueRandomIndex(int min, int max)
    {
        int r;

        do
        {
            r = Random.Range(min, max);
        } while (valoresRandom.Contains(r));

        return r;
    }
}
