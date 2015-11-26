using UnityEngine;
using System.Collections;

public abstract class Line : Attack
{
    public Line(Player caster) : base(caster)
    {
        mShape = Shape.Line;
    }
}
