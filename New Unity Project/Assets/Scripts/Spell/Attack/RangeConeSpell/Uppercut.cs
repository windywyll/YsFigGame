using UnityEngine;
using System.Collections;

public class Uppercut : Cone
{
    public Uppercut(Player caster) : base(caster)
    {
        mName = "Uppercut";
        mDamage = 10;
        mCoolDown = 10;
        mAngle = 30;
        mRange = 2;
    }

    public override void applySpell(Player target)
    {
        base.applySpell(target);
        target.push(2);
    }


}
