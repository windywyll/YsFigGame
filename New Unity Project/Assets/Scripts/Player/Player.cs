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
    Poison,
    Death
}

public class Player : MonoBehaviour
{
    private Breed mBreed;
    private Job mJob;

    private DictionaryFX mDictionaryFX;

    public GameObject mAOEShape;
    public GameObject mCircleShape;
    public GameObject mConeShape;
    public GameObject mCrossShape;
    public GameObject mLineShape;
    public GameObject mRingShape;

    private State mState;
    private float mDurationState;
    public float mStartTimeState;
    public float mTimeSinceLastPoisonDamage = 0;

    private string mName;
    private float mLife;
    private float mSpeed;
    private float mExperience;
    private float mLevel;

    private float mBasicDamage;

    private List<Spell> mSpells;
    private List<Item> mItems;

    void Start()
    {
        mDictionaryFX = this.gameObject.GetComponent<DictionaryFX>();
    }

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

    public void damage(float mDamage)
    {
        mLife -= mDamage;
        if(mLife <= 0)
        {
            changeState(State.Death,-1);
        }
    }

    public void push(int v)
    {

    }

    public void applyState()
    {
        switch (mState)
        {
            case State.Fast:
                if(mStartTimeState + mDurationState <= Time.time)
                {
                    mSpeed /= 1.25f;
                    mState = State.Normal;
                }
                break;
            case State.Poison:
                if(mStartTimeState + mDurationState <= Time.time)
                {
                    mLife -= 3;
                    mState = State.Normal;
                    break;
                }
                if(mStartTimeState + mTimeSinceLastPoisonDamage <= Time.time)
                {
                    mLife -= 3;
                    mTimeSinceLastPoisonDamage = Time.time;
                }
                break;
            case State.Slow:

                break;
            case State.Stun:
                if (mStartTimeState + mDurationState <= Time.time)
                {
                    mState = State.Normal;
                }
                break;
            default:

                break;
        }
    }

    internal void cast(int nbSpell)
    {
        Spell castSpell = mSpells[nbSpell - 1];

        if (castSpell.timeStart + castSpell.mCoolDown > Time.time)
        {
            return;
        }

        castSpell.spellCast();
        switch (castSpell.mType)
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
        castSpell.applySpell(this);
    }

    private void castSpellAttack(Attack castSpell)
    {
        GameObject instanceSpell;
        GameObject instanceFx;
        List<GameObject> listFX = new List<GameObject>();

        switch (castSpell.mShape)
        {
            case Shape.AOE:
                instanceSpell = Instantiate(mAOEShape, transform.position, transform.rotation) as GameObject;
                instanceSpell.transform.parent = this.gameObject.transform;
                instanceSpell.transform.localScale = new Vector3(castSpell.mRange, 0.01f, castSpell.mRange);
                instanceSpell.GetComponent<OnCollisionEnter>().setNameSpell(castSpell.mName);

                listFX = mDictionaryFX.getValueFromKey(castSpell.mName);

                if (listFX == null) break;

                foreach(GameObject fx in listFX)
                {
                    instanceFx = Instantiate(fx, transform.position, transform.rotation) as GameObject;
                    instanceFx.transform.parent = instanceSpell.gameObject.transform;
                }

                break;
            case Shape.Circle:
                instanceSpell = Instantiate(mCircleShape, transform.position, transform.rotation) as GameObject;
                instanceSpell.transform.parent = this.gameObject.transform;
                instanceSpell.transform.Translate(0, 0, castSpell.mRange);
                instanceSpell.transform.localScale = new Vector3(((Circle)castSpell).mSizeAOE, 0.01f, ((Circle)castSpell).mSizeAOE);
                instanceSpell.GetComponent<OnCollisionEnter>().setNameSpell(castSpell.mName);

                listFX = mDictionaryFX.getValueFromKey(castSpell.mName);

                if (listFX == null) break;

                foreach (GameObject fx in listFX)
                {
                    if(fx.name == "Explosion")
                    {

                    }
                    else
                    {
                        instanceFx = Instantiate(fx, transform.position, transform.rotation) as GameObject;
                        instanceFx.transform.parent = instanceSpell.gameObject.transform;
                        ((Circle)castSpell).targetFX = instanceSpell.transform.position;
                        ((Circle)castSpell).mStep = (((Circle)castSpell).targetFX - this.gameObject.transform.position) / castSpell.mTimeLifeSpell;
                    }
                }

                break;
            case Shape.Cone:
                instanceSpell = Instantiate(mConeShape, transform.position, transform.rotation) as GameObject;
                instanceSpell.transform.parent = this.gameObject.transform;
                instanceSpell.transform.localScale = new Vector3(castSpell.mRange, 0.01f, castSpell.mRange);
                instanceSpell.transform.Rotate(0, 180, 0);
                instanceSpell.transform.Translate(0, 0, -3 * castSpell.mRange);
                instanceSpell.GetComponent<OnCollisionEnter>().setNameSpell(castSpell.mName);

                listFX = mDictionaryFX.getValueFromKey(castSpell.mName);

                if (listFX == null) break;

                foreach (GameObject fx in listFX)
                {
                    instanceFx = Instantiate(fx, transform.position, transform.rotation) as GameObject;
                    instanceFx.transform.parent = instanceSpell.gameObject.transform;
                }

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
                instanceSpell.transform.localScale = new Vector3(0.5f, 0.01f, castSpell.mRange);
                instanceSpell.transform.Translate(new Vector3(0, 0, castSpell.mRange));

                instanceSpell.GetComponent<OnCollisionEnter>().setNameSpell(castSpell.mName);

                listFX = mDictionaryFX.getValueFromKey(castSpell.mName);

                if (listFX == null) break;

                foreach (GameObject fx in listFX)
                {
                    instanceFx = Instantiate(fx, transform.position, transform.rotation) as GameObject;
                    instanceFx.transform.parent = instanceSpell.gameObject.transform;
                }

                break;
            default:
                instanceSpell = Instantiate(mRingShape, transform.position, transform.rotation) as GameObject;
                instanceSpell.transform.parent = this.gameObject.transform;
                instanceSpell.transform.localScale.Set(castSpell.mRange, 0.01f, castSpell.mRange);
                instanceSpell.GetComponent<OnCollisionEnter>().setNameSpell(castSpell.mName);

                listFX = mDictionaryFX.getValueFromKey(castSpell.mName);

                if (listFX == null) break;

                foreach (GameObject fx in listFX)
                {
                    instanceFx = Instantiate(fx, transform.position, transform.rotation) as GameObject;
                    instanceFx.transform.parent = instanceSpell.gameObject.transform;
                }

                break;
        }
        GameManager.mSpellsInScene.Add(castSpell, instanceSpell);
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
        return mSpeed + 0.1f*mBreed.getSpeed();
    }

    public State getState()
    {
        return mState;
    }

    public float getDamage()
    {
        return mBasicDamage + mBreed.getDamage();
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

    public void setBreed(Breed breed)
    {
        mBreed = breed;
        mLife += mBreed.getLife();
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
