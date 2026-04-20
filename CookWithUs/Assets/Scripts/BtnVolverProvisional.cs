using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnVolverProvisional : MonoBehaviour
{
    public void ChangeScene()
    {
        SceneManager.LoadScene("CityMap");
    }
}