using UnityEngine;
using System.Collections;
using System;

public class Sprint : Heal
{
    public Sprint(Player caster) : base(caster)
    {

    }

    public override void applySpell(Player target)
    {
        target.setSpeed(target.getSpeed() * 1.25f);
    }
}
