using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Botones : MonoBehaviour
{
    public static event Action<int> OnPointsAdded;
    public int points = 25;

    public void AddPoints()
    {
        OnPointsAdded.Invoke(points);
    }

    public void checkAnswer(bool isCorrect)
    {

        if (CompareTag("CORRECT"))
        {
            isCorrect = true;
            print("CORRECT BOTONES");
        }
        else if (CompareTag("WRONG"))
        {
            isCorrect = false;
            print("WRONG BOTONES");
        }


        BattleSystem bs = FindFirstObjectByType<BattleSystem>();
        bs.ElegirRespuesta(isCorrect);
    }
}
