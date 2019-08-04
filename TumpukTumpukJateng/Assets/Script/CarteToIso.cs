using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarteToIso : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 tileSizeInUnits = new Vector3(1.0f, 0.715f, 1f);
    void Start()
    {
        Vector3 localPosition = gameObject.transform.localPosition;
        // transform.localPosition = Cartesian_to_Isometric(localPosition);

    }

    // Update is called once per frame
    void Update()
    {

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
