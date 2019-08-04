using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuUIManager : MonoBehaviour
{


    public void ExitButtonPressed()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
    public void PlayButtonPressed()
    {
        SceneManager.LoadScene("Map");
    }



}
