using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class peta : MonoBehaviour
{
    public Button playButton;

    public void SetStageNull()
    {
        GameScript.stage = 0;
    }
    public void SetStageSemarang()
    {
        GameScript.stage = 1;
    }
    public void SetStageJepara()
    {
        if (PlayerPrefs.GetInt("isStage1Unlocked") == 1)
        {
            GameScript.stage = 2;
        }
    }
    public void SetStageBlore()
    {
        if (PlayerPrefs.GetInt("isStage2Unlocked") == 1)
        {
            GameScript.stage = 3;
        }
    }
    public void SetStageWonogiri()
    {
        if (PlayerPrefs.GetInt("isStage3Unlocked") == 1)
        {
            GameScript.stage = 4;
        }
    }
    public void SetStageMagelang()
    {
        GameScript.stage = 5;
    }
    public void SetStageBanyumas()
    {
        GameScript.stage = 6;
    }
    public void SetStageTegal()
    {
        GameScript.stage = 7;
    }
    void CheckReady()
    {
        if (GameScript.stage == 0)
        {
            playButton.interactable = false;
        }
        else
        {
            playButton.interactable = true;
        }
    }
    public GameObject unlockJepara, unlockBlora, unlockWonogiri, unlockMagelang, unlockBanyumas, unlockTegal;
    public GameObject lockJepara, lockBlora, lockWonogiri, lockMagelang, lockBanyumas, lockTegal;
    public GameObject smgStar, jprStar, blrStar, wngStar, mglStar, bnyStar, tglStar;
    public Sprite star1, star2, star3;
    void setStar()
    {
        if (PlayerPrefs.GetInt("starStage1") == 1)
            smgStar.GetComponent<Image>().sprite = star1;
        else if (PlayerPrefs.GetInt("starStage1") == 2)
            smgStar.GetComponent<Image>().sprite = star2;
        else if (PlayerPrefs.GetInt("starStage1") == 3)
            smgStar.GetComponent<Image>().sprite = star3;

        if (PlayerPrefs.GetInt("starStage2") == 1)
            jprStar.GetComponent<Image>().sprite = star1;
        else if (PlayerPrefs.GetInt("starStage2") == 2)
            jprStar.GetComponent<Image>().sprite = star2;
        else if (PlayerPrefs.GetInt("starStage3") == 3)
            jprStar.GetComponent<Image>().sprite = star3;

        if (PlayerPrefs.GetInt("starStage3") == 1)
            blrStar.GetComponent<Image>().sprite = star1;
        else if (PlayerPrefs.GetInt("starStage3") == 2)
            blrStar.GetComponent<Image>().sprite = star2;
        else if (PlayerPrefs.GetInt("starStage3") == 3)
            blrStar.GetComponent<Image>().sprite = star3;

        if (PlayerPrefs.GetInt("starStage4") == 1)
            wngStar.GetComponent<Image>().sprite = star1;
        else if (PlayerPrefs.GetInt("starStage4") == 2)
            wngStar.GetComponent<Image>().sprite = star2;
        else if (PlayerPrefs.GetInt("starStage4") == 3)
            wngStar.GetComponent<Image>().sprite = star3;

        if (PlayerPrefs.GetInt("starStage5") == 1)
            mglStar.GetComponent<Image>().sprite = star1;
        else if (PlayerPrefs.GetInt("starStage5") == 2)
            mglStar.GetComponent<Image>().sprite = star2;
        else if (PlayerPrefs.GetInt("starStage5") == 3)
            mglStar.GetComponent<Image>().sprite = star3;

        if (PlayerPrefs.GetInt("starStage6") == 1)
            bnyStar.GetComponent<Image>().sprite = star1;
        else if (PlayerPrefs.GetInt("starStage6") == 2)
            bnyStar.GetComponent<Image>().sprite = star2;
        else if (PlayerPrefs.GetInt("starStage6") == 3)
            bnyStar.GetComponent<Image>().sprite = star3;

        if (PlayerPrefs.GetInt("starStage7") == 1)
            tglStar.GetComponent<Image>().sprite = star1;
        else if (PlayerPrefs.GetInt("starStage7") == 2)
            tglStar.GetComponent<Image>().sprite = star2;
        else if (PlayerPrefs.GetInt("starStage7") == 3)
            tglStar.GetComponent<Image>().sprite = star3;
    }
    void unlockStage()
    {
        if (PlayerPrefs.GetInt("isStage1Unlocked") == 1)
        {
            lockJepara.SetActive(false);
            unlockJepara.SetActive(true);
        }
        else
        {
            lockJepara.SetActive(true);
            unlockJepara.SetActive(false);
        }
        if (PlayerPrefs.GetInt("isStage2Unlocked") == 1)
        {
            lockBlora.SetActive(false);
            unlockBlora.SetActive(true);
        }
        if (PlayerPrefs.GetInt("isStage3Unlocked") == 1)
        {
            lockWonogiri.SetActive(false);
            unlockWonogiri.SetActive(true);
        }
        if (PlayerPrefs.GetInt("isStage4Unlocked") == 1)
        {
            lockMagelang.SetActive(false);
            unlockMagelang.SetActive(true);
        }
        if (PlayerPrefs.GetInt("isStage5Unlocked") == 1)
        {
            lockBanyumas.SetActive(false);
            unlockBanyumas.SetActive(true);
        }
        if (PlayerPrefs.GetInt("isStage6Unlocked") == 1)
        {
            lockTegal.SetActive(false);
            unlockTegal.SetActive(true);
        }
    }
    public void Play()
    {
        SceneManager.LoadScene("GameScene");
    }
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("isStage1Unlocked", 0);
        PlayerPrefs.SetInt("isStage2Unlocked", 0);
        PlayerPrefs.SetInt("isStage3Unlocked", 0);
        PlayerPrefs.SetInt("isStage4Unlocked", 0);
        PlayerPrefs.SetInt("isStage5Unlocked", 0);
        PlayerPrefs.SetInt("isStage6Unlocked", 0);

        Debug.Log(PlayerPrefs.GetInt("isStage1Unlocked"));

        // PlayerPrefs.SetInt("starStage1", 0);
        // PlayerPrefs.SetInt("starStage2", 0);
        // PlayerPrefs.SetInt("starStage3", 0);
        // PlayerPrefs.SetInt("starStage4", 0);
        // PlayerPrefs.SetInt("starStage5", 0);
        // PlayerPrefs.SetInt("starStage6", 0);
        // PlayerPrefs.SetInt("starStage7", 0);
        // Debug.Log(PlayerPrefs.GetInt("starStage1"));
    }

    // Update is called once per frame
    void Update()
    {
        CheckReady();
        unlockStage();
        setStar();
    }
}
