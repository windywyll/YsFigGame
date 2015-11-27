using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

public class PlayerManager : MonoBehaviour
{
    public GameObject winPanel;

    public  Player mPlayer1;
    private  Collider colliderPlayer1;
    private NavMeshAgent agentPlayer1;

    public  Player mPlayer2;
    private  Collider colliderPlayer2;
    private NavMeshAgent agentPlayer2;

    private int winner = 0;

    void Awake()
    {
        DontDestroyOnLoad(this);
        colliderPlayer1 = mPlayer1.GetComponent<Collider>();
        agentPlayer1 = mPlayer1.GetComponent<NavMeshAgent>();
        colliderPlayer2 = mPlayer2.GetComponent<Collider>();
        agentPlayer2 = mPlayer2.GetComponent<NavMeshAgent>();
        buildPlayer1();
        buildPlayer2();
        TigerMen tiger = new TigerMen();
        Satyr satyre = new Satyr();
        mPlayer1.setBreed(tiger);
        mPlayer2.setBreed(satyre);
    }

    public void movePlayer1(Vector3 targetPosition, RaycastHit hit)
    {
        if(mPlayer1.getState() == State.Stun)
        {
            return;
        }
        targetPosition = hit.point;
        targetPosition.y = 0.90f;

        mPlayer1.transform.LookAt(targetPosition);
        agentPlayer1.destination = targetPosition;
    }
    
    public void movePlayer2(Vector3 targetPosition, RaycastHit hit)
    {
        if (mPlayer2.getState() == State.Stun)
        {
            return;
        }
        targetPosition = hit.point;
        targetPosition.y = 0.90f;

        mPlayer2.transform.LookAt(targetPosition);
        agentPlayer2.destination = targetPosition;
    }

    void Update()
    {
        Debug.Log("LifePlayer1 : " + mPlayer1.getLife());
        Debug.Log("LifePlayer2 : " + mPlayer2.getLife());
        Debug.Log("StatePlayer1 : " + mPlayer1.getState());
        Debug.Log("StatePlayer2 : " + mPlayer2.getState());

        if (mPlayer1.getState() == State.Death)
        {
            winner = 2;
            victory();
        }

        if (mPlayer2.getState() == State.Death)
        {
            winner = 1;
            victory();
        }
    }


    public void victory()
    {
        winPanel.SetActive(true);

        if(winner == 1)
            winPanel.GetComponent<ScriptPanelWin>().setWinner(true);
        if(winner == 2)
            winPanel.GetComponent<ScriptPanelWin>().setWinner(false);
    }

    private void buildPlayer1()
    {
        mPlayer1.buildAsTank();
    }

    private void buildPlayer2()
    {
        mPlayer2.buildAsMage();
    }

    internal void player1CastSpell(int nbSpell)
    {
        mPlayer1.cast(nbSpell);
    }

    internal void player2CastSpell(int nbSpell)
    {
        mPlayer2.cast(nbSpell);
    }
}
