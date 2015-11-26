using UnityEngine;
using System.Collections;

public abstract class Cross : Attack
{
    public Cross(Player caster) : base(caster)
    {
        mShape = Shape.Cross;
    }
}
