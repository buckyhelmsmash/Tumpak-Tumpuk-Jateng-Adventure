using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gallery : MonoBehaviour
{
    public GameObject Info;

    public GameObject Semarang, Jepara, Blora, Wonogiri, Magelang, Banyumas, tegal;
    // Start is called before the first frame update
    void Start()
    {
        // unlockAll();
        // lockAll();
    }
    void unlockAll()
    {
        PlayerPrefs.SetInt("isStage1Unlocked", 1);
        PlayerPrefs.SetInt("isStage2Unlocked", 1);
        PlayerPrefs.SetInt("isStage3Unlocked", 1);
        PlayerPrefs.SetInt("isStage4Unlocked", 1);
        PlayerPrefs.SetInt("isStage5Unlocked", 1);
        PlayerPrefs.SetInt("isStage6Unlocked", 1);
        PlayerPrefs.SetInt("isStage7Unlocked", 1);
    }
    void lockAll()
    {
        PlayerPrefs.SetInt("isStage1Unlocked", 0);
        PlayerPrefs.SetInt("isStage2Unlocked", 0);
        PlayerPrefs.SetInt("isStage3Unlocked", 0);
        PlayerPrefs.SetInt("isStage4Unlocked", 0);
        PlayerPrefs.SetInt("isStage5Unlocked", 0);
        PlayerPrefs.SetInt("isStage6Unlocked", 0);
        PlayerPrefs.SetInt("isStage7Unlocked", 0);
    }
    // Update is called once per frame
    void Update()
    {
        unlockedStage();
    }
    void unlockedStage()
    {
        if (PlayerPrefs.GetInt("isStage1Unlocked") == 1)
        {
            Semarang.SetActive(true);
        }
        if (PlayerPrefs.GetInt("isStage2Unlocked") == 1)
        {
            Jepara.SetActive(true);
        }
        if (PlayerPrefs.GetInt("isStage3Unlocked") == 1)
        {
            Blora.SetActive(true);
        }
        if (PlayerPrefs.GetInt("isStage4Unlocked") == 1)
        {
            Wonogiri.SetActive(true);
        }
    }
    public Sprite smgInfo, jprInfo, blrInfo, wngInfo, mglInfo, bnyInfo, tglInfo;
    public void setInfoSemarang()
    {
        Info.GetComponent<Image>().sprite = smgInfo;
    }
    public void setInfoJepara()
    {
        Info.GetComponent<Image>().sprite = jprInfo;
    }
    public void setInfoBlora()
    {
        Info.GetComponent<Image>().sprite = blrInfo;
    }
    public void setInfoWonogiri()
    {
        Info.GetComponent<Image>().sprite = wngInfo;
    }
    public void setInfoMagelang()
    {
        Info.GetComponent<Image>().sprite = mglInfo;
    }
    public void setInfoBanyumas()
    {
        Info.GetComponent<Image>().sprite = bnyInfo;
    }
    public void setInfoTegal()
    {
        Info.GetComponent<Image>().sprite = tglInfo;
    }
}
