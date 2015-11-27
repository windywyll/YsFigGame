using UnityEngine;
using System.Collections;
using System;

public class InputManager : MonoBehaviour
{
    private Touch[] touches;

    private PlayerManager playerManager;

    //private bool player1Moving = false;
    //private bool player2Moving = false;

    void Awake()
    {
        DontDestroyOnLoad(this);
        playerManager = this.gameObject.GetComponent<PlayerManager>();
    }

    void Update()
    {
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
                        //player1Moving = true;
                        playerManager.movePlayer1(targetPosition, hit);
                    }
                    if (playerManager.mPlayer2.gameObject == hit.transform.gameObject)
                    {
                        //player2Moving = true;
                        playerManager.movePlayer2(targetPosition, hit);
                    }
                }
            }
        }
    }

    public void onClickPlayer1Spell1()
    {
        playerManager.player1CastSpell(1);
    }
    public void onClickPlayer1Spell2()
    {
        playerManager.player1CastSpell(2);
    }
    public void onClickPlayer1Spell3()
    {
        playerManager.player1CastSpell(3);
    }
    public void onClickPlayer1Spell4()
    {
        playerManager.player1CastSpell(4);
    }
    public void onClickPlayer2Spell1()
    {
        playerManager.player2CastSpell(1);
    }
    public void onClickPlayer2Spell2()
    {
        playerManager.player2CastSpell(2);
    }
    public void onClickPlayer2Spell3()
    {
        playerManager.player2CastSpell(3);
    }
    public void onClickPlayer2Spell4()
    {
        playerManager.player2CastSpell(4);
    }
}
