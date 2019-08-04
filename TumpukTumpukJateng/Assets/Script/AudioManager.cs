using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioSource bgm, button, swipe, skorakhir, stuck;

    public static bool MusicBool, SFXBool;
    // static AudioManager instance = null;

    // void Awake()
    // {
    //     if (instance != null)
    //     {
    //         Destroy(gameObject);
    //     }
    //     else
    //     {
    //         instance = this;
    //         GameObject.DontDestroyOnLoad(gameObject);
    //     }
    // }
    private void Start()
    {
        MusicBool = true;
        SFXBool = true;
    }
    private void Update()
    {
        // Debug.Log(SFXBool);
    }

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
    public void SwipeSound()
    {
        if (SFXBool == true)
        {
            swipe.Play();
        }
    }
    public void SkorAkhirSound()
    {
        if (SFXBool == true)
        {
            skorakhir.Play();
        }
    }
    public void StuckSound()
    {
        if (SFXBool == true)
        {
            stuck.Play();
        }
    }

}
