using UnityEngine;
using System.Collections;

public abstract class TargetSpell : Attack
{
    public TargetSpell()
    {
        mShape = Shape.Target;
    }
}
