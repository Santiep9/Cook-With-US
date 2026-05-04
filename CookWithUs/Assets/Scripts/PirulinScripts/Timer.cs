using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    float currentTime;
    float startingTime;

    [SerializeField] TextMeshProUGUI countdownText;

    [SerializeField] BattleSystem bs;
    [SerializeField] GameController gameController;

    bool turnoActivo;

    private void Start()
    {
        startingTime = 5f;
        currentTime = startingTime;
    }

    private void Update()
    {
        if(bs.currentState == BattleState.PLAYERTURN)
        {
            countdownText.gameObject.SetActive(true);

            if (!turnoActivo)
            {
                currentTime = startingTime;
                turnoActivo = true;
            }

            CuentaAtras();
        }
        else
        {
            countdownText.gameObject.SetActive(false);
            turnoActivo = false;
        }
    }
    public float CuentaAtras()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            bs.ElegirRespuesta(false);
            gameController.IncreaseProgressAmount(-25);
        }
        return currentTime;
    }
}
