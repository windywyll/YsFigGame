using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static Dictionary<Spell, GameObject> mSpellsInScene;
    private DictionaryFX mDictionaryFX;
    private bool mExplosionDid = false;

    void Awake()
    {
        mSpellsInScene = new Dictionary<Spell, GameObject>();
        mDictionaryFX = this.gameObject.GetComponent<DictionaryFX>();
    }

    void Update()
    {
        foreach(KeyValuePair<Spell, GameObject> spell in mSpellsInScene)
        {
            if(spell.Key.mName == "FireBall")
            {
                Transform instanceFireBall = spell.Value.transform.GetChild(0);
                GameObject instanceExplosion;
                Vector3 deplacement = ((Circle)spell.Key).mStep * Time.deltaTime;
                deplacement.y = 0;
                instanceFireBall.position += deplacement;

                if (spell.Value.transform.position.z - instanceFireBall.position.z < 0.1f)
                {
                    List<GameObject> fireBallFx = mDictionaryFX.getValueFromKey("FireBall");

                    foreach (GameObject fx in fireBallFx)
                    {
                        if (!mExplosionDid && fx.name == "Explosion")
                        {
                            mExplosionDid = true;
                            spell.Value.transform.position += new Vector3(0, 0.9f, 0);
                            instanceExplosion = Instantiate(fx, instanceFireBall.position, instanceFireBall.rotation) as GameObject;
                            instanceExplosion.transform.parent = spell.Value.gameObject.transform;
                        }
                    }
                }
            }
            if (((Attack)spell.Key).mTimeLifeSpell + spell.Key.timeStart < Time.time)
            {
                mExplosionDid = false;
                Destroy(spell.Value);
                mSpellsInScene.Remove(spell.Key);
                return;
            }
        }
    }
}
