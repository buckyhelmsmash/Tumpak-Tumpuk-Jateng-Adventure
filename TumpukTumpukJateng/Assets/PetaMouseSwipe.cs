using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PetaMouseSwipe : MonoBehaviour
{
    public GameObject Map1, Map2;
    public GameObject SwipeSound;
    private void Update()
    {
        if (SwipeManager.IsSwipingLeft())
        {
            Map1.SetActive(false);
            Map2.SetActive(true);
        }
        if (SwipeManager.IsSwipingRight())
        {
            Map1.SetActive(true);
            Map2.SetActive(false);
        }

    }
}
