using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeTester : MonoBehaviour
{
    public GameObject SM;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (SwipeManager.IsSwipingLeft())
        {
            // do something
            Debug.Log("LEFT");
        }
        if (SwipeManager.IsSwipingRight())
        {
            // do something
            Debug.Log("RIGHT");
        }
        if (SwipeManager.IsSwipingDown())
        {
            // do something
            Debug.Log("DOWN");
        }
        if (SwipeManager.IsSwipingUp())
        {
            // do something
            Debug.Log("UP");
        }
        if (SwipeManager.IsSwipingDownLeft())
        {
            // do something
            Debug.Log("DownLeft");
        }
    }
}
