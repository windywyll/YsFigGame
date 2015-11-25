using UnityEngine;
using System.Collections;

public abstract class RingSpell : Attack
{
    public RingSpell()
    {
        mShape = Shape.Ring;
    }
}