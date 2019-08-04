using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;

public class Game : MonoBehaviour
{
    public static int gridWidth = 4, gridHeight = 4;
    public static Transform[,] grid = new Transform[gridWidth, gridHeight];
    static bool isIso;
    public GameObject gameoverCanvas;
    public TextMeshProUGUI gameScoreText;
    public int score = 0;

    void CheckGridContent()
    {
        for (int y = 0; y < gridHeight; y++)
        {
            for (int x = 0; x < gridWidth; x++)
            {
                if (grid[x, y] != null)
                    Debug.Log(grid[x, y].position);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        isIso = false;
        UpdateGrid();
        // GenerateNewTile(2);
        CarteIso();
    }

    // Update is called once per frame
    void Update()
    {
        if (!CheckGameOver())
            CheckUserInput();
        else
        {
            gameoverCanvas.gameObject.SetActive(true);
        }
    }
    void CheckUserInput()
    {
        bool down = Input.GetKeyDown(KeyCode.DownArrow);
        bool up = Input.GetKeyDown(KeyCode.UpArrow);
        bool left = Input.GetKeyDown(KeyCode.LeftArrow);
        bool right = Input.GetKeyDown(KeyCode.RightArrow);

        if (down || up || left || right)
        {
            PrepareTilesForMerging();
            if (down)
            {
                IsoCarte();
                MoveAllTile(Vector2.down);
                CarteIso();
            }
            if (up)
            {
                IsoCarte();
                MoveAllTile(Vector2.up);
                CarteIso();
            }
            if (left)
            {
                IsoCarte();
                MoveAllTile(Vector2.left);
                CarteIso();
            }
            if (right)
            {
                IsoCarte();
                MoveAllTile(Vector2.right);
                CarteIso();
            }

        }
    }
    void UpdateScore()
    {
        gameScoreText.text = score.ToString("0000");
    }
    void UpdateGrid()
    {
        for (int y = 0; y < gridHeight; y++)
        {
            for (int x = 0; x < gridWidth; x++)
            {
                if (grid[x, y] != null)
                {
                    if (grid[x, y].parent == transform)
                    {
                        grid[x, y] = null;
                    }
                }
            }
        }
        // IsoCarte();
        foreach (Transform tile in transform)
        {
            Vector2 v = new Vector2(tile.localPosition.x, tile.localPosition.y);
            // v = tile.GetComponent<CarteToIso>().Isometric_to_Cartesian(tile.localPosition);
            grid[(int)v.x, (int)v.y] = tile;
        }
        // CarteIso();
    }
    bool CheckGameOver()
    {
        if (transform.childCount < gridWidth * gridHeight)
            return false;
        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                Transform currentTile = grid[x, y];
                Transform tileBelow = null;
                Transform tileBeside = null;
                int currentTileValue = currentTile.GetComponent<Tile>().tileValue;
                int tileBelowValue;
                int tileBesideValue;

                if (y != 0)
                    tileBelow = grid[x, y - 1];
                if (x != gridWidth - 1)
                    tileBeside = grid[x + 1, y];
                if (currentTileValue != 128)
                {
                    if (tileBelow != null)
                    {
                        tileBelowValue = tileBelow.GetComponent<Tile>().tileValue;
                        // if (currentTileValue != 128 || tileBelowValue != 128)
                        // {
                        if (currentTileValue == tileBelowValue)
                            return false;
                        // }
                        return true;
                    }
                    if (tileBeside != null)
                    {
                        tileBesideValue = tileBeside.GetComponent<Tile>().tileValue;
                        // if (currentTileValue != 128 || tileBesideValue != 128)
                        // {
                        if (currentTileValue == tileBesideValue)
                            return false;
                        // }
                        return true;
                    }
                }
            }
        }
        Debug.Log("GameOver");
        return true;
    }
    void MoveAllTile(Vector2 direction)
    {
        int movedTiles = 0;
        if (direction == Vector2.left)
        {
            for (int x = 0; x < gridWidth; x++)
            {
                for (int y = 0; y < gridHeight; y++)
                {
                    if (grid[x, y] != null)
                    {
                        if (MoveTile(grid[x, y], direction))
                            movedTiles++;
                    }
                }
            }
        }
        if (direction == Vector2.right)
        {
            for (int x = gridWidth - 1; x >= 0; x--)
            {
                for (int y = 0; y < gridHeight; y++)
                {
                    if (grid[x, y] != null)
                    {
                        if (MoveTile(grid[x, y], direction))
                        {
                            movedTiles++;
                        }
                    }
                }
            }
        }
        if (direction == Vector2.down)
        {
            for (int x = 0; x < gridWidth; x++)
            {
                for (int y = 0; y < gridHeight; y++)
                {
                    if (grid[x, y] != null)
                    {
                        if (MoveTile(grid[x, y], direction))
                            movedTiles++;
                    }
                }
            }
        }
        if (direction == Vector2.up)
        {
            for (int x = 0; x < gridWidth; x++)
            {
                for (int y = gridHeight - 1; y >= 0; y--)
                {
                    if (grid[x, y] != null)
                    {
                        if (MoveTile(grid[x, y], direction))
                        {
                            movedTiles++;
                        }
                    }
                }
            }
        }
        if (movedTiles != 0)
        {
            score += 5;
            UpdateScore();
            GenerateNewTile(1);
        }

    }
    bool MoveTile(Transform tile, Vector2 direction)
    {
        Vector2 startPos = tile.localPosition;
        while (true)
        {
            tile.transform.localPosition += (Vector3)direction;
            Vector2 pos = tile.transform.localPosition;
            if (ChecIsInsideGrid(pos))
            {
                if (CheckIsAtValidPosition(pos))
                {
                    UpdateGrid();
                }
                else
                {
                    if (!CheckAndCombineTile(tile))
                    {
                        tile.transform.localPosition -= (Vector3)direction;
                        if (tile.transform.localPosition == (Vector3)startPos)
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                }
            }
            else
            {
                tile.transform.localPosition -= (Vector3)direction;
                if (tile.transform.localPosition == (Vector3)startPos)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
    bool CheckAndCombineTile(Transform movingTile)
    {
        Vector2 pos = movingTile.transform.localPosition;

        Transform collidingTile = grid[(int)pos.x, (int)pos.y];

        int movingTileValue = movingTile.GetComponent<Tile>().tileValue;
        int collidingTileValue = collidingTile.GetComponent<Tile>().tileValue;
        if (movingTileValue != 128)
        {
            if (movingTileValue == collidingTileValue && !movingTile.GetComponent<Tile>().mergedThisTurn && !collidingTile.GetComponent<Tile>().mergedThisTurn)
            {
                Destroy(movingTile.gameObject);
                Destroy(collidingTile.gameObject);

                grid[(int)pos.x, (int)pos.y] = null;

                string newTileName = "tile_" + movingTileValue * 2;

                GameObject newTile = (GameObject)Instantiate(Resources.Load("Prefabs/" + newTileName, typeof(GameObject)), pos, Quaternion.identity);
                newTile.transform.parent = transform;
                newTile.GetComponent<Tile>().mergedThisTurn = true;

                UpdateGrid();

                if (movingTileValue == 2)
                    score += 5;
                else if (movingTileValue == 4)
                    score += 10;
                else if (movingTileValue == 8)
                    score += 20;
                else if (movingTileValue == 16)
                    score += 40;
                else if (movingTileValue == 32)
                    score += 80;
                else if (movingTileValue == 64)
                    score += 160;

                UpdateScore();
                return true;
            }
        }

        return false;
    }
    void GenerateNewTile(int howMany)
    {
        for (int i = 0; i < howMany; i++)
        {
            Vector2 newTileLocation = GetRandomTileLocation();
            string tile = "tile_2";

            GameObject newTile = (GameObject)Instantiate(Resources.Load("Prefabs/" + tile, typeof(GameObject)), newTileLocation, Quaternion.identity);
            newTile.transform.parent = transform;
        }
        UpdateGrid();
    }
    Vector2 GetRandomTileLocation()
    {
        List<int> x = new List<int>();
        List<int> y = new List<int>();

        for (int j = 0; j < gridWidth; j++)
        {
            for (int i = 0; i < gridHeight; i++)
            {
                if (grid[j, i] == null)
                {
                    x.Add(j);
                    y.Add(i);
                }
            }
        }
        int randIndex = Random.Range(0, x.Count);
        int randX = x.ElementAt(randIndex);
        int randY = y.ElementAt(randIndex);

        return new Vector2(randX, randY);
    }
    bool ChecIsInsideGrid(Vector2 pos)
    {
        if (pos.x >= 0 && pos.x < gridWidth && pos.y >= 0 && pos.y < gridHeight)
        {
            return true;
        }
        // Debug.Log("ChekIsInsideGrid: False " + pos.ToString());
        return false;
    }
    bool CheckIsAtValidPosition(Vector2 pos)
    {
        if (grid[(int)pos.x, (int)pos.y] == null)
            return true;
        return false;
    }
    void PrepareTilesForMerging()
    {
        foreach (Transform t in transform)
        {
            t.GetComponent<Tile>().mergedThisTurn = false;
        }
    }
    public void PlayAgain()
    {
        grid = new Transform[gridWidth, gridHeight];
        score = 0;
        List<GameObject> childern = new List<GameObject>();
        foreach (Transform t in transform)
        {
            childern.Add(t.gameObject);
        }
        childern.ForEach(t => DestroyImmediate(t));
        gameoverCanvas.gameObject.SetActive(false);
        GenerateNewTile(2);
    }
    void CarteIso()
    {
        if (isIso == false)
        {
            for (int x = 0; x < gridWidth; x++)
            {
                for (int y = 0; y < gridHeight; y++)
                {
                    if (grid[x, y] != null)
                    {
                        grid[x, y].localPosition = Cartesian_to_Isometric(grid[x, y].localPosition);
                    }
                }
            }
            isIso = true;
        }

    }
    void IsoCarte()
    {
        if (isIso == true)
        {
            for (int x = 0; x < gridWidth; x++)
            {
                for (int y = 0; y < gridHeight; y++)
                {
                    if (grid[x, y] != null)
                    {
                        grid[x, y].localPosition = Isometric_to_Cartesian(grid[x, y].localPosition);
                    }
                }
            }
            isIso = false;
        }
    }
    public Vector2 Cartesian_to_Isometric(Vector2 Carte)
    {
        Vector2 Isometric = new Vector2(0, 0);
        if (Carte.x == 0 && Carte.y == 0)
        {
            Isometric.x = 0;
            Isometric.y = 0;
            return Isometric;
        }
        else if (Carte.x == 1 && Carte.y == 0)
        {
            Isometric.x = 0.5f;
            Isometric.y = -0.36f;
            return Isometric;
        }
        else if (Carte.x == 2 && Carte.y == 0)
        {
            Isometric.x = 1f;
            Isometric.y = -0.71f;
            return Isometric;
        }
        else if (Carte.x == 3 && Carte.y == 0)
        {
            Isometric.x = 1.5f;
            Isometric.y = -1.07f;
            return Isometric;
        }
        else if (Carte.x == 0 && Carte.y == 1)
        {
            Isometric.x = 0.5f;
            Isometric.y = 0.36f;
            return Isometric;
        }
        else if (Carte.x == 1 && Carte.y == 1)
        {
            Isometric.x = 1f;
            Isometric.y = 0f;
            return Isometric;
        }
        else if (Carte.x == 2 && Carte.y == 1)
        {
            Isometric.x = 1.5f;
            Isometric.y = -0.36f;
            return Isometric;
        }
        else if (Carte.x == 3 && Carte.y == 1)
        {
            Isometric.x = 2f;
            Isometric.y = -0.71f;
            return Isometric;
        }
        else if (Carte.x == 0 && Carte.y == 2)
        {
            Isometric.x = 1;
            Isometric.y = 0.71f;
            return Isometric;
        }
        else if (Carte.x == 1 && Carte.y == 2)
        {
            Isometric.x = 1.5f;
            Isometric.y = 0.36f;
            return Isometric;
        }
        else if (Carte.x == 2 && Carte.y == 2)
        {
            Isometric.x = 2f;
            Isometric.y = 0f;
            return Isometric;
        }
        else if (Carte.x == 3 && Carte.y == 2)
        {
            Isometric.x = 2.5f;
            Isometric.y = -0.36f;
            return Isometric;
        }
        else if (Carte.x == 0 && Carte.y == 3)
        {
            Isometric.x = 1.5f;
            Isometric.y = 1.07f;
            return Isometric;
        }
        else if (Carte.x == 1 && Carte.y == 3)
        {
            Isometric.x = 2f;
            Isometric.y = 0.71f;
            return Isometric;
        }
        else if (Carte.x == 2 && Carte.y == 3)
        {
            Isometric.x = 2.5f;
            Isometric.y = 0.36f;
            return Isometric;
        }
        else if (Carte.x == 3 && Carte.y == 3)
        {
            Isometric.x = 3f;
            Isometric.y = 0f;
            return Isometric;
        }
        else
        {
            return Carte;
        }
    }
    public Vector2 Isometric_to_Cartesian(Vector2 Iso)
    {
        Vector2 Cartesian = new Vector2(0, 0);
        if (Iso.x == 0 && Iso.y == 0)
        {
            Cartesian.x = 0;
            Cartesian.y = 0;
            return Cartesian;
        }
        else if (Iso.x == 0.5f && Iso.y == -0.36f)
        {
            Cartesian.x = 1;
            Cartesian.y = 0;
            return Cartesian;
        }
        else if (Iso.x == 1f && Iso.y == -0.71f)
        {
            Cartesian.x = 2;
            Cartesian.y = 0;
            return Cartesian;
        }
        else if (Iso.x == 1.5f && Iso.y == -1.07f)
        {
            Cartesian.x = 3;
            Cartesian.y = 0;
            return Cartesian;
        }
        else if (Iso.x == 0.5f && Iso.y == 0.36f)
        {
            Cartesian.x = 0;
            Cartesian.y = 1;
            return Cartesian;
        }
        else if (Iso.x == 1 && Iso.y == 0)
        {
            Cartesian.x = 1f;
            Cartesian.y = 1f;
            return Cartesian;
        }
        else if (Iso.x == 1.5f && Iso.y == -0.36f)
        {
            Cartesian.x = 2;
            Cartesian.y = 1;
            return Cartesian;
        }
        else if (Iso.x == 2f && Iso.y == -0.71f)
        {
            Cartesian.x = 3;
            Cartesian.y = 1;
            return Cartesian;
        }
        else if (Iso.x == 1 && Iso.y == 0.71f)
        {
            Cartesian.x = 0;
            Cartesian.y = 2;
            return Cartesian;
        }
        else if (Iso.x == 1.5f && Iso.y == 0.36f)
        {
            Cartesian.x = 1;
            Cartesian.y = 2;
            return Cartesian;
        }
        else if (Iso.x == 2f && Iso.y == 0f)
        {
            Cartesian.x = 2;
            Cartesian.y = 2;
            return Cartesian;
        }
        else if (Iso.x == 2.5f && Iso.y == -0.36f)
        {
            Cartesian.x = 3;
            Cartesian.y = 2;
            return Cartesian;
        }
        else if (Iso.x == 1.5f && Iso.y == 1.07f)
        {
            Cartesian.x = 0;
            Cartesian.y = 3;
            return Cartesian;
        }
        else if (Iso.x == 2f && Iso.y == 0.71f)
        {
            Cartesian.x = 1;
            Cartesian.y = 3;
            return Cartesian;
        }
        else if (Iso.x == 2.5f && Iso.y == 0.36f)
        {
            Cartesian.x = 2;
            Cartesian.y = 3;
            return Cartesian;
        }
        else if (Iso.x == 3f && Iso.y == 0f)
        {
            Cartesian.x = 3;
            Cartesian.y = 3;
            return Cartesian;
        }
        else
        {
            return Iso;
        }

    }
}
