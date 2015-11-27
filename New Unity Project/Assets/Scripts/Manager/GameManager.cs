using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static Dictionary<Spell, GameObject> mSpellsInScene;

    void Awake()
    {
        mSpellsInScene = new Dictionary<Spell, GameObject> ();
    }
	
	void Update ()
    {
        foreach(KeyValuePair<Spell, GameObject> spell in mSpellsInScene)
        {
            if(spell.Key.mName == "FireBall")
            {

            }
            if (((Attack)spell.Key).mTimeLifeSpell + spell.Key.timeStart < Time.time)
            {
                Destroy(spell.Value);
                mSpellsInScene.Remove(spell.Key);
                return;
            }
        }
    }
}
