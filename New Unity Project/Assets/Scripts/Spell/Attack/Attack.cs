using UnityEngine;
using System.Collections;

public enum Shape
{
    AOE,
    Cone,
    Line,
    Ring,
    Player,
    Circle,
    Cross
}

public abstract class Attack : Spell
{
    internal Shape mShape;
    internal float mDamage;
    internal float mRange;
    internal float mAngle;
}
