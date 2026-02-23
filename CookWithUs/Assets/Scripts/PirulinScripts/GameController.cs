using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    int progressAmount;
    public Slider progressSlider;

    private void Start()
    {
        progressAmount = 0;
        progressSlider.value = 0;
        Botones.OnPointsAdded += IncreaseProgressAmount;
    }
    void IncreaseProgressAmount(int amount)
    {
        progressAmount += amount;
        progressSlider.value = progressAmount;
        if(progressAmount >= 100)
        {
            //level complete
            Debug.Log("acabo");
        }
    }
}
