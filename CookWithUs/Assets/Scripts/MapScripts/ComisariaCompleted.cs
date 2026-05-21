using UnityEngine;

public class ComisariaCompleted : MonoBehaviour
{
    public Areas areas;

    public GameObject mjohn;

    private void Start()
    {
        if (areas.mjohnCompleted)
        {
            mjohn.SetActive(false);
        }
    }
}
