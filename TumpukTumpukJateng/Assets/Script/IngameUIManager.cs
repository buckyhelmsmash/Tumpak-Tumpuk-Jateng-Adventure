using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IngameUIManager : MonoBehaviour
{
    public Button NextStageBtn;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameScript.stage == 7)
        {
            NextStageBtn.enabled = false;
        }
    }
    public void Reload()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void ExitButtonPressed()
    {
        Application.Quit();
    }
    public void NextStage()
    {
        SceneManager.LoadScene("GameScene");
        GameScript.stage += 1;
    }
}
