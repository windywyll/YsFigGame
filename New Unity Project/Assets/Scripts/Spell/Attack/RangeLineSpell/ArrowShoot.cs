using UnityEngine;
using System.Collections;

public class ArrowShoot : Line
{
    public ArrowShoot(Player caster) : base(caster)
    {
        mDamage = 1;
        mCoolDown = 2;
        mAngle = 0;
        mRange = 4;
    }

    public override void applySpell(Player target)
    {
        base.applySpell(target);
    }
}
