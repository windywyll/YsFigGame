using UnityEngine;
using System.Collections;

public abstract class Circle : Attack
{
    public float mSizeAOE;
    public Vector3 targetFX;
    public Vector3 mStep = new Vector3();

    public Circle(Player caster) : base(caster)
    {
        targetFX = new Vector3();
        mSizeAOE = 2;
        mShape = Shape.Circle;
    }
}
