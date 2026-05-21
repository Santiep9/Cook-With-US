using UnityEngine;

public class ManagerCompleted : MonoBehaviour
{
    public Areas areas;

    public GameObject jusep;

    private void Start()
    {
        if(areas.jusepCompleted)
        {
            jusep.SetActive(false);
        }
    }
}
