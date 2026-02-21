using System;
using UnityEngine;
using UnityEngine.UIElements;

public class Botones : MonoBehaviour
{
    public static event Action<int> OnPointsAdded;
    public int points = 25;
    public void AddPoints()
    {
        OnPointsAdded.Invoke(points);

    }
}
