using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiagonalSwipe : MonoBehaviour
{
    private float fingerStartTime = 0.0f;
    private Vector2 fingerStartPos = Vector2.zero;

    private bool isSwipe = false;
    private float minSwipeDist = 30.0f;
    private float maxSwipeTime = 0.5f;


    void Update()
    {

        if (Input.touchCount > 0 && Time.timeScale > 0.0f)
        {

            foreach (Touch touch in Input.touches)
            {

                switch (touch.phase)
                {

                    case TouchPhase.Began:
                        /* this is a new touch */
                        isSwipe = true;
                        fingerStartTime = Time.time;
                        fingerStartPos = touch.position;
                        break;

                    case TouchPhase.Canceled:
                        /* The touch is being canceled */
                        isSwipe = false;
                        break;

                    case TouchPhase.Ended:

                        float gestureTime = Time.time - fingerStartTime;
                        float gestureDist = (touch.position - fingerStartPos).magnitude;

                        if (isSwipe && gestureTime < maxSwipeTime && gestureDist > minSwipeDist)
                        {

                            Vector2 direction = touch.position - fingerStartPos;
                            //Vector2 swipeType = Vector2.zero;
                            int swipeType = -1;
                            if (Mathf.Abs(direction.normalized.x) > 0.65)
                            {

                                if (Mathf.Sign(direction.x) > 0) swipeType = 0; // swipe right
                                else swipeType = 1; // swipe left

                            }
                            else if (Mathf.Abs(direction.normalized.y) > 0.65)
                            {
                                if (Mathf.Sign(direction.y) > 0) swipeType = 2; // swipe up
                                else swipeType = 3; // swipe down
                            }
                            else
                            {
                                // diagonal:
                                if (Mathf.Sign(direction.x) > 0)
                                {

                                    if (Mathf.Sign(direction.y) > 0) swipeType = 4; // swipe diagonal up-right
                                    else swipeType = 5; // swipe diagonal down-right

                                }
                                else
                                {

                                    if (Mathf.Sign(direction.y) > 0) swipeType = 6; // swipe diagonal up-left
                                    else swipeType = 7; // swipe diagonal down-left

                                }

                            }

                            switch (swipeType)
                            {

                                case 0: //right
                                    Debug.Log("RIGHT");
                                    break;


                                case 1: //left
                                    Debug.Log("LEFT");
                                    break;

                                case 2: //up
                                    Debug.Log("UP");
                                    break;

                                case 3: //down
                                    Debug.Log("DOWN");
                                    break;

                                case 4: //up right
                                    Debug.Log("UP_RIGHT");
                                    break;

                                case 5: //down right
                                    Debug.Log("DOWN_RIGHT");
                                    break;

                                case 6: //up left
                                    Debug.Log("UP_LEFT");
                                    break;

                                case 7: //down left
                                    Debug.Log("DOWN_LEFT");
                                    break;

                            }

                        }

                        break;

                }

            }

        }
    }
}
