using UnityEngine;
using System.Collections;

public abstract class AOE : Attack
{
    public AOE(Player caster) : base(caster)
    {
        mShape = Shape.AOE;
    }
}
