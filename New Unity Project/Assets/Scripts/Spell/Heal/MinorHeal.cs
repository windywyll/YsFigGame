using UnityEngine;
using System.Collections;
using System;

public class MinorHeal : Heal
{
    public MinorHeal(Player caster) : base(caster)
    {

    }

    public override void applySpell(Player target)
    {
        target.setLife(target.getLife() + 10);
    }
}
