using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PlayerManager : MonoBehaviour
{
    private float mLife;
    private float mMana;
    private float mExperience;
    private List<Spell> mSpells;
     
	void Start ()
    {
        DontDestroyOnLoad(this);

        mSpells = new List<Spell>();
        mExperience = 0;

        //A voir avec les GD
        mLife = 0;
        mMana = 0;
    }
	
	void Update ()
    {
	
	}
}
