using UnityEngine;
using System.Collections;

public abstract class CircleSpell : Attack
{
    public CircleSpell()
    {
        mShape = Shape.Circle;
    }
}