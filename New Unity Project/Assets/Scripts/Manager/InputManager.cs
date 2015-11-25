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

        foreach (Touch touch in touches)
        {
            if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
            {
                // Construct a ray from the current touch coordinates
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;
                Vector3 targetPosition = new Vector3();
                if (Physics.Raycast(ray, out hit))
                {
                    if(playerManager.mPlayer1.gameObject == hit.transform.gameObject)
                    {
                        playerManager.movePlayer1(targetPosition, hit);
                    }
                    if (playerManager.mPlayer2.gameObject == hit.transform.gameObject)
                    {
                        playerManager.movePlayer2(targetPosition, hit);
                    }
                }
            }
        }
    }
}
