using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioSource bgm, button;

    public static bool MusicBool, SFXBool;
    // private void Awake()
    // {
    //     MusicBool = true;
    //     SFXBool = true;
    //     GameObject[] UIbutton = GameObject.FindGameObjectsWithTag("UIbutton");
    //     foreach (GameObject button in UIbutton)
    //     {
    //         button.GetComponent<Button>().onClick.AddListener(ButtonClickSound);
    //     }

    // }
    public void MusicToggle()
    {
        if (MusicBool == true)
        {
            MusicBool = false;
            bgm.Play();
        }
        else if (MusicBool == false)
        {
            MusicBool = true;
            bgm.Pause();
        }
    }
    public void SFXToggle()
    {
        if (SFXBool == true)
            SFXBool = false;
        else if (SFXBool == false)
        {
            SFXBool = true;
        }
    }
    public void ButtonClickSound()
    {
        if (SFXBool == true)
        {
            button.Play();
        }
    }

}
