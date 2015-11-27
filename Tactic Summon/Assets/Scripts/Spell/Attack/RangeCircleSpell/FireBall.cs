using UnityEngine;
using System.Collections;

public class FireBall : Circle
{

    public FireBall(Player caster) : base(caster)
    {
        mName = "FireBall";
        mDamage = 10;
        mCoolDown = 5;
        mRange = 4;
        mAngle = 0;
        timeStart = -mCoolDown;
        mTimeLifeSpell = 1.2f;
        
    }

    public override void applySpell(Player target)
    {
        base.applySpell(target);
    }
}
