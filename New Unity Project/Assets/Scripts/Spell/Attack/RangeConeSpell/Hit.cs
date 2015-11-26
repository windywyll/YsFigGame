using UnityEngine;
using System.Collections;

public class Hit : Cone
{
    public Hit(Player caster) : base(caster)
    {
        mDamage = 4;
        mCoolDown = 1.5f;
        mAngle = 30;
        mRange = 2;
    }
}
