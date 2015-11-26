using UnityEngine;
using System.Collections;

public class FireBall : Circle { // l'accolade elle t'empapaoute cedric
    public FireBall(Player caster) : base(caster)
    {
        mDamage = 10;
        mCoolDown = 15;
        mRange = 4;
        mAngle = 0;
    }

    public override void applySpell(Player target)
    {
        base.applySpell(target);
    }
}
