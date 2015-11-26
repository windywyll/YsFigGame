using UnityEngine;
using System.Collections;

public class MagicShoot : Line
{
    public MagicShoot(Player caster) : base(caster)
    {
        mName = "MagicShoot";
        mDamage = 2;
        mCoolDown = 1.5f;
        mRange = 6;
        mAngle = 0;
    }

    public override void applySpell(Player target)
    {
        base.applySpell(target);
    }
}
