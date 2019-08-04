using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Achivement : MonoBehaviour
{
    public TextMeshProUGUI gameScoreText, gameHighscoreText;
    public Image starImage;
    public Sprite star1, star2, star3;
    static bool is4, is8, is16, is32, is64, is128;
    public void ResetAchivement()
    {
        is4 = false;
        is8 = false;
        is16 = false;
        is32 = false;
        is64 = false;
        is128 = false;
        popSkorAkhir = false;
        savedStar = PlayerPrefs.GetInt("starStage" + GameScript.stage);
    }
    static bool popSkorAkhir;
    public void poppedSkorAkhir()
    {
        popSkorAkhir = true;
    }
    public GameObject skorAkhir;
    public GameObject SlotAchivement;
    public GameObject lvl1, lvl2, lvl3, lvl4, lvl5, lvl6;
    public Sprite lvl0Sprite, lvl1Sprite, lvl2Sprite, lvl3Sprite, lvl4Sprite, lvl5Sprite, lvl6Sprite;
    // Start is called before the first frame update
    void Start()
    {
        ResetAchivement();
    }
    public GameObject Audio;
    public GameObject rumahFinal;
    public Sprite smgFinal, jprFinal, blrFinal, wngFinal, mglFinal, bnyFinal, tglFinal;
    void setRumahFinal()
    {
        if (GameScript.stage == 1)
        {
            rumahFinal.GetComponent<Image>().sprite = smgFinal;
        }
        else if (GameScript.stage == 2)
        {
            rumahFinal.GetComponent<Image>().sprite = jprFinal;
        }
        else if (GameScript.stage == 3)
        {
            rumahFinal.GetComponent<Image>().sprite = blrFinal;
        }
        else if (GameScript.stage == 4)
        {
            rumahFinal.GetComponent<Image>().sprite = wngFinal;
        }
        else if (GameScript.stage == 5)
        {
            rumahFinal.GetComponent<Image>().sprite = mglFinal;
        }
        else if (GameScript.stage == 6)
        {
            rumahFinal.GetComponent<Image>().sprite = bnyFinal;
        }
        else if (GameScript.stage == 7)
        {
            rumahFinal.GetComponent<Image>().sprite = tglFinal;
        }
    }
    void setSkorAkhir()
    {
        gameScoreText.text = GameScript.score.ToString("0000");
        gameHighscoreText.text = GameScript.highscore.ToString("0000");
    }
    int savedStar;
    int star = 0;
    bool isStarSet = false;
    void setStar()
    {
        float min = gameObject.GetComponent<GameScript>().minute;
        float sec = gameObject.GetComponent<GameScript>().second;
        float time = (min * 60) + sec;

        if (time < 300)
        {
            star = 3;
            starImage.sprite = star3;
        }
        else if (time >= 300 && time <= 600)
        {
            star = 2;
            starImage.sprite = star2;
        }
        else if (time > 600)
        {
            star = 1;
            starImage.sprite = star1;
        }

    }
    void saveStar()
    {
        if (star > savedStar)
        {
            PlayerPrefs.SetInt("starStage" + GameScript.stage, star);
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (Is128())
        {
            is128 = true;
        }
        CheckMilestone();
        UpdateAchivement();
        skorakhirResult();
    }
    void skorakhirResult()
    {
        setRumahFinal();
        setSkorAkhir();
        if (isStarSet == false)
        {

            setStar();
            saveStar();
        }
    }
    void UpdateAchivement()
    {
        if (is4 == true)
        {
            lvl1.GetComponent<Image>().sprite = lvl1Sprite;
        }
        else
        {
            lvl1.GetComponent<Image>().sprite = lvl0Sprite;
        }


        if (is8 == true)
        {
            lvl2.GetComponent<Image>().sprite = lvl2Sprite;
        }
        else
        {
            lvl2.GetComponent<Image>().sprite = lvl0Sprite;
        }


        if (is16 == true)
        {
            lvl3.GetComponent<Image>().sprite = lvl3Sprite;
        }
        else
        {
            lvl3.GetComponent<Image>().sprite = lvl0Sprite;
        }

        if (is32 == true)
        {
            lvl4.GetComponent<Image>().sprite = lvl4Sprite;
        }
        else
        {
            lvl4.GetComponent<Image>().sprite = lvl0Sprite;
        }

        if (is64 == true)
        {
            lvl5.GetComponent<Image>().sprite = lvl5Sprite;
        }
        else
        {
            lvl5.GetComponent<Image>().sprite = lvl0Sprite;
        }

        if (is128 == true)
        {
            lvl6.GetComponent<Image>().sprite = lvl6Sprite;
            if (popSkorAkhir == false)
            {
                skorAkhir.gameObject.SetActive(true);
                Debug.Log("UNLOCKED");
                gameObject.GetComponent<GameScript>().pauseGame();
                isStarSet = true;
                PlayerPrefs.SetInt("isStage" + GameScript.stage + "Unlocked", 1);
                // Audio.GetComponent<AudioManager>().SkorAkhirSound();
            }
        }
        else
        {
            lvl6.GetComponent<Image>().sprite = lvl0Sprite;
        }
    }
    public void CheckMilestone()
    {
        if (is4 == false)
        {
            // Debug.Log("4 = false");
            if (Is4())
            {
                is4 = true;
            }
        }

        if (is8 == false)
        {
            // Debug.Log("8 = false");
            if (Is8())
            {
                is8 = true;
            }
        }

        if (is16 == false)
        {
            // Debug.Log("16 = false");
            if (Is16())
            {
                is16 = true;
            }
        }

        if (is32 == false)
        {
            // Debug.Log("32 = false");
            if (Is32())
            {
                is32 = true;
            }
        }

        if (is64 == false)
        {
            // Debug.Log("64 = false");
            if (Is64())
            {
                is64 = true;
            }
        }
        else

        if (is128 == false)
        {
            // Debug.Log("128 = false");
            if (Is128())
            {
                is128 = true;
            }
        }
    }
    bool Is4()
    {
        for (int x = 0; x < GameScript.gridWidth; x++)
        {
            for (int y = 0; y < GameScript.gridHeight; y++)
            {
                if (GameScript.grid[x, y] != null)
                {
                    if (GameScript.grid[x, y].GetComponent<Tile>().tileValue == 4)
                        return true;
                }
            }
        }
        return false;
    }
    bool Is8()
    {
        for (int x = 0; x < GameScript.gridWidth; x++)
        {
            for (int y = 0; y < GameScript.gridHeight; y++)
            {
                if (GameScript.grid[x, y] != null)
                {
                    if (GameScript.grid[x, y].GetComponent<Tile>().tileValue == 8)
                        return true;
                }
            }
        }
        return false;
    }
    bool Is16()
    {
        for (int x = 0; x < GameScript.gridWidth; x++)
        {
            for (int y = 0; y < GameScript.gridHeight; y++)
            {
                if (GameScript.grid[x, y] != null)
                {
                    if (GameScript.grid[x, y].GetComponent<Tile>().tileValue == 16)
                        return true;
                }
            }
        }
        return false;
    }
    bool Is32()
    {
        for (int x = 0; x < GameScript.gridWidth; x++)
        {
            for (int y = 0; y < GameScript.gridHeight; y++)
            {
                if (GameScript.grid[x, y] != null)
                {
                    if (GameScript.grid[x, y].GetComponent<Tile>().tileValue == 32)
                        return true;
                }
            }
        }
        return false;
    }
    bool Is64()
    {
        for (int x = 0; x < GameScript.gridWidth; x++)
        {
            for (int y = 0; y < GameScript.gridHeight; y++)
            {
                if (GameScript.grid[x, y] != null)
                {
                    if (GameScript.grid[x, y].GetComponent<Tile>().tileValue == 64)
                        return true;
                }
            }
        }
        return false;
    }
    bool Is128()
    {
        for (int x = 0; x < GameScript.gridWidth; x++)
        {
            for (int y = 0; y < GameScript.gridHeight; y++)
            {
                if (GameScript.grid[x, y] != null)
                {
                    if (GameScript.grid[x, y].GetComponent<Tile>().tileValue == 128)
                    {
                        Debug.Log("128 founded");
                        return true;
                    }
                }
            }
        }
        return false;
    }
}
