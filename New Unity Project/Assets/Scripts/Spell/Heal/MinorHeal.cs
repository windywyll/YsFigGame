using UnityEngine;
using System.Collections;
using System;

public class MinorHeal : Heal
{
    public MinorHeal(Player caster) : base(caster)
    {
        mCoolDown = 25;
        timeStart = -mCoolDown;
        mName = "MinorHeal";
    }

    public override void applySpell(Player target)
    {
        target.setLife(target.getLife() + 10);
    }
}
