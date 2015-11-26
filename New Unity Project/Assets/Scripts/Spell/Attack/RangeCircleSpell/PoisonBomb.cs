using UnityEngine;
using System.Collections;

public class PoisonBomb : Circle
{
    private int mDuration;

    public PoisonBomb(Player caster) : base(caster)
    {
        mName = "PoisonBomb";
        mDamage = 3;
        mDuration = 5;
        mCoolDown = 20;
        mAngle = 0;
        mRange = 4;
    }

    public override void applySpell(Player target)
    {
        base.applySpell(target);
        target.changeState(State.Poison, mDuration);
    }
}
