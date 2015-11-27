using UnityEngine;
using System.Collections;

public class FireBall : Circle
{
    public float mStep = 0.1f;

    public FireBall(Player caster) : base(caster)
    {
        mName = "FireBall";
        mDamage = 10;
        mCoolDown = 15;
        mRange = 4;
        mAngle = 0;
        timeStart = -mCoolDown;
        mTimeLifeSpell = 2.5f;
    }

    public override void applySpell(Player target)
    {
        base.applySpell(target);
    }
}
