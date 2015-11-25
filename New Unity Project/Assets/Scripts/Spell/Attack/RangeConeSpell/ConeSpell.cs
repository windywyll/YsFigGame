using UnityEngine;
using System.Collections;

public abstract class ConeSpell : Attack
{
    public ConeSpell()
    {
        mShape = Shape.Cone;
    }
}