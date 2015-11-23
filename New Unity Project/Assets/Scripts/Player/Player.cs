using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Player : MonoBehaviour
{
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
        mSpells = new List<Spell>();
        mExperience = 0;

        //A voir avec les GD
        mLife = 0;
        mMana = 0;
    }

}
