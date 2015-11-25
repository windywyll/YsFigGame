using UnityEngine;
using System.Collections;
using System;

public class InputManager : MonoBehaviour
{
    private Touch[] touches;

    private PlayerManager playerManager;

    private int fingerIDPlayer1 = -1;
    private int fingerIDPlayer2 = -1;
    private bool startDid = false;

    void Start()
    {
        DontDestroyOnLoad(this);
        playerManager = this.gameObject.GetComponent<PlayerManager>();
    }

    void Update()
    {
        Debug.Log("Begin InputManager");

        touches = Input.touches;

        if(!allPlayersTouching())
        {
            assignNewId();
        }

#if UNITY_EDITOR
        Debug.Log("testo");
        if (Input.GetMouseButton(0))
        {
            Vector2 mousPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            playerManager.movePlayer1(mousPos);
        }

#endif

        foreach (Touch touch in touches)
        {
            Debug.Log("ForEach");
            if (touch.phase == TouchPhase.Ended)
            {
                reinitIDPlayer(touch);
            }
            else
            {
                if (touch.fingerId == fingerIDPlayer1)
                {
                    playerManager.movePlayer1(touch.position);
                }
                /*else if (touch.fingerId == fingerIDPlayer2)
                {
                    playerManager.movePlayer2(touch.position);
                }*/
            }
        }
    }

    private void reinitIDPlayer(Touch touch)
    {
        if (touch.fingerId == fingerIDPlayer1)
        {
            fingerIDPlayer1 = -1;
        }
        else if (touch.fingerId == fingerIDPlayer2)
        {
            fingerIDPlayer2 = -1;
        }
    }

    private bool allPlayersTouching()
    {
        return fingerIDPlayer1 != -1 && fingerIDPlayer2 != -1;
    }

    private void assignNewId()
    {
        if(fingerIDPlayer1 == -1)
        {
            fingerIDPlayer1 = playerManager.getIDTouchInRangePlayer1(touches);
        }
        if(fingerIDPlayer2 == -1)
        {
            fingerIDPlayer2 = playerManager.getIDTouchInRangePlayer2(touches);
        }
    }

    private void getFirstIDFinger()
    {
        fingerIDPlayer1 = playerManager.getIDTouchInRangePlayer1(touches);
        fingerIDPlayer2 = playerManager.getIDTouchInRangePlayer2(touches);
    }
}
