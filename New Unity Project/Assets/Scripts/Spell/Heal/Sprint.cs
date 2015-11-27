using UnityEngine;
using System.Collections;
using System;

public class Sprint : Heal
{
    private float mDuration;

    public Sprint(Player caster) : base(caster)
    {
        mName = "Sprint";
        mDuration = 3;
        timeStart = -mCoolDown;
    }

    public override void applySpell(Player target)
    {
        target.setSpeed(target.getSpeed() * 1.25f);
        target.changeState(State.Fast, mDuration);
        target.mStartTimeState = Time.time;
    }
}
