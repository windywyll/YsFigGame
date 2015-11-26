using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

public enum State
    {
    Normal,
    Stun,
    Slow,
    Fast, 
    Poison
}

public class Player : MonoBehaviour
{
    private Breed mBreed;
    private Job mJob;

    internal void damage(float mDamage)
    {
        throw new NotImplementedException();
    }

    internal void push(int v)
    {
        throw new NotImplementedException();
    }

    public AOE mAOEShape;
    public Circle mCircleShape;
    public Cone mConeShape;
    public Cross mCrossShape;
    public Line mLineShape;
    public Ring mRingShape;

    private State mState;
    private float mDurationState;

    private string mName;
    private float mLife;
    private float mSpeed;
    private float mExperience;
    private float mLevel;

    private float mBasicDamage;

    private List<Spell> mSpells;
    private List<Item> mItems;

    public Player()
    {
        mLife = 100;
        mSpeed = 0.5f;
        mExperience = 0;
        mLevel = 0;

        mBasicDamage = 5;

        mSpells = new List<Spell>();
        mItems = new List<Item>();
    }

    public void changeState(State state, float durationState)
    {
        mDurationState = durationState;
        mState = state;
    }

    public void applyState()
    {

    }

    internal void cast(int nbSpell)
    {
        Spell castSpell = mSpells[nbSpell-1];
        switch(castSpell.mType)
        {
            case Type.Attack :
                castSpellAttack((Attack)castSpell);
                break;
            case Type.Heal:
                castSpellHeal((Heal)castSpell);
                break;
        }
    }

    private void castSpellHeal(Heal castSpell)
    {
        throw new NotImplementedException();
    }

    private void castSpellAttack(Attack castSpell)
    {
        GameObject instanceSpell;
        switch (castSpell.mShape)
        {
            case Shape.AOE:
                instanceSpell = Instantiate(mAOEShape, transform.position, transform.rotation) as GameObject;
                instanceSpell.transform.parent = this.gameObject.transform;
                instanceSpell.transform.localScale.Set(castSpell.mRange, 0.01f, castSpell.mRange);
                instanceSpell.GetComponent<OnCollisionEnter>().setNameSpell(castSpell.mName);                
                break;
            case Shape.Circle:
                instanceSpell = Instantiate(mCircleShape, transform.position, transform.rotation) as GameObject;
                instanceSpell.transform.parent = this.gameObject.transform;
                instanceSpell.transform.position = transform.position + transform.position.normalized*castSpell.mRange;
                instanceSpell.transform.localScale.Set(((Circle)castSpell).mSizeAOE, 0.01f, ((Circle)castSpell).mSizeAOE);
                instanceSpell.GetComponent<OnCollisionEnter>().setNameSpell(castSpell.mName);
                break;
            case Shape.Cone:
                instanceSpell = Instantiate(mConeShape, transform.position, transform.rotation) as GameObject;
                instanceSpell.transform.parent = this.gameObject.transform;
                instanceSpell.transform.localScale.Set(castSpell.mRange, 0.01f, castSpell.mRange);
                instanceSpell.GetComponent<OnCollisionEnter>().setNameSpell(castSpell.mName);
                break;
            case Shape.Cross:
                instanceSpell = Instantiate(mCrossShape, transform.position, transform.rotation) as GameObject;
                instanceSpell.transform.parent = this.gameObject.transform;
                Transform onZ = instanceSpell.transform.FindChild("onZ");
                Transform onX = instanceSpell.transform.FindChild("onX");
                onX.localScale.Set(castSpell.mRange, 0.01f, 0.01f);
                onZ.localScale.Set(0.01f, 0.01f, castSpell.mRange);
                instanceSpell.GetComponent<OnCollisionEnter>().setNameSpell(castSpell.mName);
                break;
            case Shape.Line:
                instanceSpell = Instantiate(mLineShape, transform.position, transform.rotation) as GameObject;
                instanceSpell.transform.parent = this.gameObject.transform;
                instanceSpell.transform.localScale.Set(0.5f, 0.01f, castSpell.mRange);
                instanceSpell.transform.position += new Vector3(0, 0, castSpell.mRange / 2);
                instanceSpell.GetComponent<OnCollisionEnter>().setNameSpell(castSpell.mName);
                break;
            case Shape.Ring:
                instanceSpell = Instantiate(mRingShape, transform.position, transform.rotation) as GameObject;
                instanceSpell.transform.parent = this.gameObject.transform;
                instanceSpell.transform.localScale.Set(castSpell.mRange, 0.01f, castSpell.mRange);
                instanceSpell.GetComponent<OnCollisionEnter>().setNameSpell(castSpell.mName);
                break;
        }
    }

    public void spellHasHit(string spellHit, Player playerHit)
    {
        foreach(Spell spell in mSpells)
        {
            if(spellHit == spell.mName)
            {
                if( ((Attack)spell).mShape == Shape.Cone)
                {
                    spell.applySpell(playerHit);
                }
                else
                {
                    spell.applySpell(playerHit);
                }
                return;
            }
        }
    }

    public float getSpeed()
    {
        return mSpeed + mBreed.getSpeed() + mJob.getSpeed();
    }

    public void setSpeed(float speed)
    {
        mSpeed = speed;
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
        mSpells.Add(new Bolas(this));
        mSpells.Add(new Hit(this));
        mSpells.Add(new Uppercut(this));
        mSpells.Add(new Sprint(this));
    }

    internal void buildAsMage()
    {
        mSpells.Add(new FireBall(this));
        mSpells.Add(new MagicShoot(this));
        mSpells.Add(new FireAura(this));
        mSpells.Add(new MinorHeal(this));
    }

    internal void setLife(float life)
    {
        mLife = life;
    }

    internal float getLife()
    {
        return mLife;
    }
}
