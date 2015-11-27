using UnityEngine;
using System.Collections;
using System;

public class Bolas : Line
{
    public Bolas(Player caster) : base(caster)
    {
        mName = "Bolas";
        mDamage = 0;
        mCoolDown = 15;
        mAngle = 0;
        mRange = 4;
        timeStart = -mCoolDown;
        mTimeLifeSpell = 0.5f;
    }

    public override void applySpell(Player target)
    {
        base.applySpell(target);
        target.changeState(State.Slow, 5);
    }
}
