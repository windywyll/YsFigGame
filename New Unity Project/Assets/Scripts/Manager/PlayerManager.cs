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

    public void movePlayer1(Vector3 touchposition)
    {
        Debug.Log("In MovePlayer1" + touchposition);
        Debug.Log("tatata " + mPlayer1.transform.position);
        
        Vector3 direction = new Vector3(touchposition.x - mPlayer1.transform.position.x - Screen.width / 2, 
                                        0,
                                        touchposition.y - Screen.height/2 - mPlayer1.transform.position.y);

        Debug.Log("Super Biclette " + direction);

        direction = direction.normalized * mPlayer1.getSpeed();
        

        mPlayer1.transform.position += direction;

        mPlayer1.transform.LookAt(direction);
        Debug.Log("Biclette " + direction);
    }
    
    public void movePlayer2(Vector3 touchposition)
    {
        Vector3 direction = new Vector3(touchposition.x - mPlayer2.transform.position.x,
                                        touchposition.y - mPlayer2.transform.position.y,
                                        mPlayer2.transform.position.z);

        direction = direction.normalized * mPlayer2.getSpeed();

        mPlayer2.transform.position += direction;

        mPlayer2.transform.LookAt(direction);
    }

    /*private void buildPlayer1(List<Spell> spellsChoosen)
    {
        return 0;
    }

    private void buildPlayer2(List<Spell> spellsChoosen)
    {
        return 0;
    }*/

    public int getIDTouchInRangePlayer1(Touch[] touches)
    {
        foreach(Touch touch in touches)
        {
            Vector3 pos = touch.position;
            pos.z = touch.position.y;
            pos.y = mPlayer1.transform.position.z;
            if (colliderPlayer1.bounds.Contains(pos))
            {
                return touch.fingerId;
            }
        }
        return -1;
    }

    public int getIDTouchInRangePlayer2(Touch[] touches)
    {
        foreach (Touch touch in touches)
        {
            Vector3 pos = touch.position;
            pos.z = touch.position.y;
            pos.y = mPlayer2.transform.position.z;
            if (colliderPlayer2.bounds.Contains(pos))
            {
                return touch.fingerId;
            }
        }
        return -1;
    }
}
