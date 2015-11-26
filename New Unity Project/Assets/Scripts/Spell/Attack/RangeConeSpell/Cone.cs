using UnityEngine;
using System.Collections;

public abstract class Cone : Attack
{
    public Cone(Player caster) : base(caster)
    {
        mShape = Shape.Cone;
    }
}
