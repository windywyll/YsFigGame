using UnityEngine;
using System.Collections;

public abstract class Line : Attack
{
    public Vector3 targetFX;
    public Line(Player caster) : base(caster)
    {
        targetFX = new Vector3();
        mShape = Shape.Line;
    }
}
