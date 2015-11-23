using UnityEngine;
using System.Collections;
using System;

public class Joystick
{
    private Vector3 mStartPosition;
    private Vector3 mCurrentPosition;
    private float mRange;
    private bool mIsActiv;
    private int mIDFinger;

    public Joystick(Vector3 startPosition, float range)
    {
        mStartPosition = startPosition;
        mCurrentPosition = new Vector3(0, 0, 0);
        mRange = range;
        mIsActiv = false;
        mIDFinger = -1;
    }

    public int getFingerID ()
    {
        return mIDFinger;
    }

    public void desactiveJoystick()
    {
        mIsActiv = false;
        mIDFinger = -1;
    }

    public bool isActiv()
    {
        return mIsActiv;
    }

    public int activJoystickAndGetIDIfInRange(Touch touch)
    {
        if(touch.position.x < mStartPosition.x + mRange &&
           touch.position.x > mStartPosition.x - mRange &&
           touch.position.y < mStartPosition.y + mRange &&
           touch.position.y > mStartPosition.y - mRange)
        {
            mIsActiv = true;
            mIDFinger = touch.fingerId;
            //Envoie Input
        }
        return mIDFinger;
    }

    public void getInput(Touch touch)
    {
        //Envoie Input;
    }
}
