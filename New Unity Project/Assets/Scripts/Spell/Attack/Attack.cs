using UnityEngine;
using System.Collections;

public enum Shape
{
    AOE,
    Cone,
    Line,
    Ring,
    Circle,
    Cross
}

public class Attack : Spell
{
    public Shape mShape;
    internal float mDamage;
    internal float mRange;
    internal float mAngle;
    public float mTimeLifeSpell;

    public Attack(Player caster) : base(caster)
    {
        mType = Type.Attack;
    }

    public override void applySpell(Player target)
    {
        if (mCaster == target)
            return;
        target.damage(mDamage + mCaster.getDamage());
    }
}
