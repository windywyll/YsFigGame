using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

public class PlayerManager : MonoBehaviour
{
    public  Player mPlayer1;
    private  Collider colliderPlayer1;

    public  Player mPlayer2;
    private  Collider colliderPlayer2;

    void Start()
    {
        DontDestroyOnLoad(this);
        colliderPlayer1 = mPlayer1.GetComponent<Collider>();
        colliderPlayer2 = mPlayer2.GetComponent<Collider>();
    }

    public void movePlayer1(Vector3 targetPosition, RaycastHit hit)
    {
        targetPosition = hit.point;
        targetPosition.y = -1f;
        mPlayer1.transform.position = targetPosition;
    }
    
    public void movePlayer2(Vector3 targetPosition, RaycastHit hit)
    {
        targetPosition = hit.point;
        targetPosition.y = -1f;
        mPlayer2.transform.position = targetPosition;
    }

    /*private void buildPlayer1(List<Spell> spellsChoosen)
    {
        return 0;
    }

    private void buildPlayer2(List<Spell> spellsChoosen)
    {
        return 0;
    }*/
}
