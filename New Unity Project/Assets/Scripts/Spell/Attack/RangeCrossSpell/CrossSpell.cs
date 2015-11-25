using UnityEngine;
using System.Collections;

public abstract class CrossSpell : Attack
{
    public CrossSpell()
    {
        mShape = Shape.Cross;
    }
}