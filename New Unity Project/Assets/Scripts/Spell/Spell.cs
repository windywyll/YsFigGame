using UnityEngine;
using System.Collections;

public enum Type
{
    Attack,
    Heal
}

public class Spell
{
    public string mName;
    internal float mCoolDown;
    public Type mType;
    internal Player mCaster;
    public float timeStart;

    public Spell(Player caster)
    {
        mCaster = caster;
    }

    public virtual void applySpell(Player target){}

    public void spellCast()
    {
        timeStart = Time.time;
    }
}
