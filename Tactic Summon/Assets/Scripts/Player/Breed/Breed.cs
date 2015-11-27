using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Breed
{
    internal string mName;
    internal float mLife;
    internal float mSpeed;
    internal float mBasicDamage;
    internal List<Job> mJobsPossibles;
    internal List<Spell> mSpellsPossibles;

    internal float getLife() { return mLife; }
    internal float getSpeed() { return mSpeed; }
    internal float getDamage() { return mBasicDamage; }
}
