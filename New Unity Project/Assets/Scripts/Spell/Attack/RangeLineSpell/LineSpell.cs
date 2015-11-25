using UnityEngine;
using System.Collections;

public abstract class LineSpell : Attack
{
    public LineSpell()
    {
        mShape = Shape.Line;
    }
}