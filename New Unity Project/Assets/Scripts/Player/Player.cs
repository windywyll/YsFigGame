using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Player : MonoBehaviour
{
    private Breed mBreed;
    private Job mJob;

    private string mName;
    private float mLife;
    private float mMana;
    private float mSpeed;
    private float mExperience;

    private float mBasicPhysicAttack;
    private float mBasicMagicAttack;

    private float mBasicPhysicResistance;
    private float mBasicMagicResistance;

    private List<Spell> mSpells;
    private List<Item> mItems;

    public Player()
    {
        mSpeed = 0.1f;
        mSpells = new List<Spell>();
        mItems = new List<Item>();
        mExperience = 0;
    }

    public float getSpeed()
    {
        return mSpeed;
    }
}
