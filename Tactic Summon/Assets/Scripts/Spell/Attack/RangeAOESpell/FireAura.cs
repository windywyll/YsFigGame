using UnityEngine;
using System.Collections;

public class FireAura : AOE {
    private int mDuration;

    public FireAura(Player caster) : base(caster)
    {
        mName = "FireAura";
        mDuration = 3;
        mDamage = 7;
        mCoolDown = 5;
        mRange = 4;
        mAngle = 0;
        timeStart = -mCoolDown;
        mTimeLifeSpell = 3;
    }

    public override void applySpell(Player target)
    {
        base.applySpell(target);
    }
}
