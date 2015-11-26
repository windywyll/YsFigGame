using UnityEngine;
using System.Collections;

public abstract class Ring : Attack
{
    public Ring(Player caster) : base(caster)
    {
        mShape = Shape.Ring;
    }
}
