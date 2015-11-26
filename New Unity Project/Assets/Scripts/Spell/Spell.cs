using UnityEngine;
using System.Collections;

public enum Type
{
    Attack,
    Heal
}

public class Spell : MonoBehaviour
{
    public string mName;
    internal float mCoolDown;
    public Type mType;
    private Player mCaster;

    public Spell(Player caster)
    {
        mCaster = caster;
    }

    public virtual void applySpell(Player target){}
}
