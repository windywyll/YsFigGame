using UnityEngine;
using System.Collections;

public abstract class Cone : Attack
{
    public Vector3 targetFX;
    public Cone(Player caster) : base(caster)
    {
        targetFX = new Vector3();
        mShape = Shape.Cone;
    }
}
