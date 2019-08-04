using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{
    private const string Down = "Down", Up = "Up", Left = "left", Right = "Right";
    public static int gridWidth = 4, gridHeight = 4;
    public static Transform[,] grid = new Transform[gridWidth, gridHeight];

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
        GenerateNewTile(2);

    }

    void Update()
    {
        CheckUserInput();
    }
    void CheckUserInput()
    {
        bool down = Input.GetKeyDown(KeyCode.DownArrow);
        bool up = Input.GetKeyDown(KeyCode.UpArrow);
        bool left = Input.GetKeyDown(KeyCode.LeftArrow);
        bool right = Input.GetKeyDown(KeyCode.RightArrow);

        if (down || up || left || right)
        {
            if (down)
            {
                MoveAllTiles(Vector2.down);
            }
            if (up)
            {
                MoveAllTiles(Vector2.up);
            }
            if (left)
            {
                MoveAllTiles(Vector2.left);
            }
            if (right)
            {
                MoveAllTiles(Vector2.right);
            }
        }
    }
    ////////////////////////////////Tile///////////////////////////
    void GenerateNewTile(int howMany)
    {
        for (int i = 0; i < howMany; i++)
        {
            Vector2 newTileLocation = GetRandomTileLocation();
            string tile = "tile_2";

            float chanceOfTwo = Random.Range(0f, 1f);
            if (chanceOfTwo < 0.1f)
            {
                tile = "tile_4";
            }
            GameObject newTile = (GameObject)Instantiate(Resources.Load("Prefabs/" + tile, typeof(GameObject)), newTileLocation, Quaternion.identity);
            newTile.transform.parent = transform;
        }
        UpdateGrid();

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

        foreach (Transform tile in transform)
        {
            Vector2 v = new Vector2(0, 0);
            v = tile.GetComponent<CarteToIso>().Isometric_to_Cartesian(tile.localPosition);
            grid[(int)v.x, (int)v.y] = tile;
        }
        // CheckGridContent();
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
    bool IsInsideGrid(Vector2 pos)
    {
        if (pos.x >= 0 && pos.x <= gridWidth - 1 && pos.y >= 0 && pos.y <= gridHeight - 1)
            return true;
        return false;
    }
    bool IsAtValidPosition(Vector2 pos)
    {
        if (grid[(int)pos.x, (int)pos.y] == null)
        {
            return true;
        }
        return false;
    }
    void MoveAllTiles(Vector2 direction)
    {
        int tileMovedCount = 0;
        if (direction == Vector2.left)
        {
            for (int x = 0; x < gridWidth; x++)
            {
                for (int y = 0; y < gridHeight; y++)
                {
                    if (grid[x, y] != null)
                    {
                        if (MoveTile(grid[x, y], direction))
                            tileMovedCount++;
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
                            tileMovedCount++;
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
                            tileMovedCount++;
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
                            tileMovedCount++;
                    }
                }
            }
        }

        if (tileMovedCount != 0)
            GenerateNewTile(1);
    }
    bool MoveTile(Transform tile, Vector2 direction)
    {
        Vector2 startPos = tile.localPosition;
        // Debug.Log(startPos);

        while (true)
        {
            tile.transform.localPosition += (Vector3)direction;
            Vector2 pos = tile.transform.localPosition;
            if (IsInsideGrid(pos))
            {
                if (IsAtValidPosition(pos))
                {
                    UpdateGrid();
                }
                else
                {
                    tile.transform.localPosition += -(Vector3)direction;
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
            else
            {
                tile.transform.localPosition += -(Vector3)direction;
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






    ////////////////////////////////Tile///////////////////////////

    ////////////////////////////Movement///////////////////////////////////////////


    ////////////////////////////Movement///////////////////////////////////////////
    public void PlayAgain()
    {
        grid = new Transform[gridWidth, gridHeight];
    }
    void CarteIso()
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
    }
    void IsoCarte()
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
    }
    public Vector2 Cartesian_to_Isometric(Vector2 Carte)
    {
        Vector2 Isometric = new Vector2(0, 0);
        if (Carte.x == 0 && Carte.y == 0)
        {
            Isometric.x = 0;
            Isometric.y = 0;
        }
        else if (Carte.x == 1 && Carte.y == 0)
        {
            Isometric.x = 0.5f;
            Isometric.y = -0.36f;
        }
        else if (Carte.x == 2 && Carte.y == 0)
        {
            Isometric.x = 1f;
            Isometric.y = -0.71f;
        }
        else if (Carte.x == 3 && Carte.y == 0)
        {
            Isometric.x = 1.5f;
            Isometric.y = -1.07f;
        }
        else if (Carte.x == 0 && Carte.y == 1)
        {
            Isometric.x = 0.5f;
            Isometric.y = 0.36f;
        }
        else if (Carte.x == 1 && Carte.y == 1)
        {
            Isometric.x = 1f;
            Isometric.y = 0f;
        }
        else if (Carte.x == 2 && Carte.y == 1)
        {
            Isometric.x = 1.5f;
            Isometric.y = -0.36f;
        }
        else if (Carte.x == 3 && Carte.y == 1)
        {
            Isometric.x = 2f;
            Isometric.y = -0.71f;
        }
        else if (Carte.x == 0 && Carte.y == 2)
        {
            Isometric.x = 1;
            Isometric.y = 0.71f;
        }
        else if (Carte.x == 1 && Carte.y == 2)
        {
            Isometric.x = 1.5f;
            Isometric.y = 0.36f;
        }
        else if (Carte.x == 2 && Carte.y == 2)
        {
            Isometric.x = 2f;
            Isometric.y = 0f;
        }
        else if (Carte.x == 3 && Carte.y == 2)
        {
            Isometric.x = 2.5f;
            Isometric.y = -0.36f;
        }
        else if (Carte.x == 0 && Carte.y == 3)
        {
            Isometric.x = 1.5f;
            Isometric.y = 1.07f;
        }
        else if (Carte.x == 1 && Carte.y == 3)
        {
            Isometric.x = 2f;
            Isometric.y = 0.71f;
        }
        else if (Carte.x == 2 && Carte.y == 3)
        {
            Isometric.x = 2.5f;
            Isometric.y = 0.36f;
        }
        else if (Carte.x == 3 && Carte.y == 3)
        {
            Isometric.x = 3f;
            Isometric.y = 0f;
        }
        return Isometric;
    }
    public Vector2 Isometric_to_Cartesian(Vector2 Iso)
    {
        Vector2 Cartesian = new Vector2(0, 0);
        if (Cartesian.x == 0 && Cartesian.y == 0)
        {
            Iso.x = 0;
            Iso.y = 0;
        }
        else if (Cartesian.x == 0.5f && Cartesian.y == -0.36f)
        {
            Iso.x = 1;
            Iso.y = 0;
        }
        else if (Cartesian.x == 1f && Cartesian.y == -0.71f)
        {
            Iso.x = 2;
            Iso.y = 0;
        }
        else if (Cartesian.x == 1.5f && Cartesian.y == -1.07f)
        {
            Iso.x = 3;
            Iso.y = 0;
        }
        else if (Cartesian.x == 0.5f && Cartesian.y == 0.36f)
        {
            Iso.x = 0;
            Iso.y = 1;
        }
        else if (Cartesian.x == 1 && Cartesian.y == 0)
        {
            Iso.x = 1f;
            Iso.y = 1f;
        }
        else if (Cartesian.x == 1.5f && Cartesian.y == -0.36f)
        {
            Iso.x = 2;
            Iso.y = 1;
        }
        else if (Cartesian.x == 2f && Cartesian.y == -0.71f)
        {
            Iso.x = 3;
            Iso.y = 1;
        }
        else if (Cartesian.x == 1 && Cartesian.y == 0.71f)
        {
            Iso.x = 0;
            Iso.y = 2;
        }
        else if (Cartesian.x == 1.5f && Cartesian.y == 0.36f)
        {
            Iso.x = 1;
            Iso.y = 2;
        }
        else if (Cartesian.x == 2f && Cartesian.y == 0f)
        {
            Iso.x = 2;
            Iso.y = 2;
        }
        else if (Cartesian.x == 2.5f && Cartesian.y == -0.36f)
        {
            Iso.x = 3;
            Iso.y = 2;
        }
        else if (Cartesian.x == 1.5f && Cartesian.y == 1.07f)
        {
            Iso.x = 0;
            Iso.y = 3;
        }
        else if (Cartesian.x == 2f && Cartesian.y == 0.71f)
        {
            Iso.x = 1;
            Iso.y = 3;
        }
        else if (Cartesian.x == 2.5f && Cartesian.y == 0.36f)
        {
            Iso.x = 2;
            Iso.y = 3;
        }
        else if (Cartesian.x == 3f && Cartesian.y == 0f)
        {
            Iso.x = 3;
            Iso.y = 3;
        }
        return Cartesian;
    }
}
