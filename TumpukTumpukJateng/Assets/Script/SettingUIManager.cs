using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingUIManager : MonoBehaviour
{
    public Sprite ToggleOn, ToggleOff;
    public Button MusicToggle, SFXToggle;

    public void MusicTogglePressed()
    {
        if (MusicToggle.image.sprite == ToggleOn)
        {
            MusicToggle.image.sprite = ToggleOff;
            Debug.Log("Music Off");
        }
        else
        {
            MusicToggle.image.sprite = ToggleOn;
            Debug.Log("Music On");
        }
    }

    public void SFXTogglePressed()
    {
        if (SFXToggle.image.sprite == ToggleOn)
        {
            SFXToggle.image.sprite = ToggleOff;
        }
        else
        {
            SFXToggle.image.sprite = ToggleOn;
        }
    }
    private void Update()
    {

    }
}
