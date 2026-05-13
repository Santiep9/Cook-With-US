using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    float currentTime;
    [SerializeField] float startingTime = 5f;

    [SerializeField] Slider sliderTimer;

    BattleSystem bs;
    GameController gc;

    bool timerFinished;
    bool isMainTimer;

    public void Setup(BattleSystem battleSystem, GameController gameController, bool mainTimer)
    {
        bs = battleSystem;
        gc = gameController;
        isMainTimer = mainTimer;
    }


    private void Start()
    {
        currentTime = startingTime;

        sliderTimer.maxValue = startingTime;
        sliderTimer.value = startingTime;
    }

    private void Update()
    {
        if (timerFinished) return;

        currentTime -= Time.deltaTime;

        sliderTimer.value = currentTime;

        if(currentTime <= 0)
        {
            timerFinished = true;

            if(isMainTimer)
            {
                bs.ElegirRespuesta(false);
                gc.IncreaseProgressAmount(-25);
            }
        }
    }
}
