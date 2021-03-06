﻿using UnityEngine;
using System.Collections;

public class StunningMine : AOE
{
    public int mDuration;

    public StunningMine (Player caster) : base(caster)
    {
        mName = "StunningMine";
        mDamage = 2;
        mCoolDown = 15;
        mAngle = 0;
        mRange = 2;
        mDuration = 2;
        timeStart = -mCoolDown;
    }

    public override void applySpell(Player target)
    {
        base.applySpell(target);
        target.changeState(State.Stun, mDuration);
        target.mStartTimeState = Time.time;
    }
}
