using UnityEngine;
using System.Collections;

public abstract class Circle : Attack
{
    public float mSizeAOE;

    public Circle(Player caster) : base(caster)
    {
        mSizeAOE = 2;
        mShape = Shape.Circle;
    }
}
