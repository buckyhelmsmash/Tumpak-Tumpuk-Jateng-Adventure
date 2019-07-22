using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUIManager : MonoBehaviour
{


    public void ExitButtonPressed()
    {
        Application.Quit();
        Debug.Log("Quit");
    }



}
