using UnityEngine;
using System.Collections;

public abstract class Heal : Spell
{
    public Heal(Player caster) : base(caster)
    {
        mType = Type.Heal;
    }
}
