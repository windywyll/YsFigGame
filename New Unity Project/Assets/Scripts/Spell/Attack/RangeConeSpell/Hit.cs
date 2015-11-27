using UnityEngine;
using System.Collections;

public class Hit : Cone
{
    public Hit(Player caster) : base(caster)
    {
        mName = "Hit";
        mDamage = 4;
        mCoolDown = 1.5f;
        mAngle = 30;
        mRange = 2;
        timeStart = -mCoolDown;
        mTimeLifeSpell = 0.5f;
    }

    public override void applySpell(Player target)
    {
        base.applySpell(target);
    }
}
