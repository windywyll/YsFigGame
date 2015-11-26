using UnityEngine;
using System.Collections;

public class DaggerStrike : Cone
{
    public DaggerStrike (Player caster) : base(caster)
    {
        mName = "DaggerStrike";
        mDamage = 15;
        mCoolDown = 10;
        mRange = 2;
        mAngle = 30;
    }

    public override void applySpell(Player target)
    {
        base.applySpell(target);
    }
}
