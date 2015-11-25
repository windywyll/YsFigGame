using UnityEngine;
using System.Collections;

public abstract class AOESpell : Attack
{
	public AOESpell ()
    {
        mShape = Shape.AOE;
        mAngle = 360;
	}
}
