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

    public Attack(Player caster) : base(caster)
    {
        mType = Type.Attack;
    }

    public override void applySpell(Player target)
    {
        target.damage(mDamage);
    }
}
