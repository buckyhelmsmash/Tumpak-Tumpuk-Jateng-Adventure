using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighscoreUIManager : MonoBehaviour
{
    public TextMeshProUGUI highScore;

    private void Update()
    {
        highScore.text = PlayerPrefs.GetInt("Highscore").ToString("0000");
    }

}
