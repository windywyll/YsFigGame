using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

public class Player : MonoBehaviour
{
    private Breed mBreed;
    private Job mJob;

    private string mName;
    private float mLife;
    private float mSpeed;
    private float mExperience;
    private float mLevel;

    private float mBasicPhysicAttack;
    private float mBasicMagicAttack;

    private float mBasicPhysicResistance;
    private float mBasicMagicResistance;

    private List<Spell> mSpells;
    private List<Item> mItems;

    public Player()
    {
        mLife = 100;
        mSpeed = 0.5f;
        mExperience = 0;
        mLevel = 0;

        mBasicPhysicAttack = 5;
        mBasicMagicAttack = 5;

        mBasicPhysicResistance = 0;
        mBasicMagicResistance = 0;

        mSpells = new List<Spell>();
        mItems = new List<Item>();
    }

    public float getSpeed()
    {
        return mSpeed;
    }

    public void addSpell(Spell spell)
    {
        mSpells.Add(spell);
    }
    public void addItem(Item item)
    {
        mItems.Add(item);
    }

    internal void buildAsTank()
    {
        mSpells.Add();
        mSpells.Add();
        mSpells.Add();
        mSpells.Add();


    }

    internal void buildAsMage()
    {
        mSpells.Add();
        mSpells.Add();
        mSpells.Add();
        mSpells.Add();


    }
}
