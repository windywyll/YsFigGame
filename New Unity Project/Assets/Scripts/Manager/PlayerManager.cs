using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PlayerManager : MonoBehaviour
{
    private Player mPlayer1;
    private Player mPlayer2;

    void Start ()
    {
        DontDestroyOnLoad(this);
        mPlayer1 = new Player();
        mPlayer2 = new Player();
    }

    void Update ()
    {
	
	}

    public static void movePlayer1(Vector2 move)
    {

    }
    public static void movePlayer2(Vector2 move)
    {

    }
}
