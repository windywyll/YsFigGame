using UnityEngine;
using System.Collections;

public enum Shape
{
    AOE,
    Cone,
    Bullet,
    Lazer
}

public abstract class Attack : Spell
{
    private Shape mShape;
    private float mDamage;
    private float mRange;

    void Start ()
    {
	
	}
	
	void Update ()
    {
	
	}
}
