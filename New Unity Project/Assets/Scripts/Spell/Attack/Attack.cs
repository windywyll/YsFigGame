using UnityEngine;
using System.Collections;

public enum Shape
{
    AOE,
    Cone,
    Line,
    Ring,
    Target,
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
