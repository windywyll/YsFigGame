using UnityEngine;
using System.Collections;

public class ArrowShoot : Line
{
    public ArrowShoot(Player caster) : base(caster)
    {
        mName = "ArrowShoot";
        mDamage = 1;
        mCoolDown = 2;
        mAngle = 0;
        mRange = 4;
        timeStart = -mCoolDown;
        mTimeLifeSpell = 0.5f;
    }

    public override void applySpell(Player target)
    {
        base.applySpell(target);
    }
}
