using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static Dictionary<Spell, GameObject> mSpellsInScene;
    private DictionaryFX mDictionaryFX;

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
                instanceFireBall.position += deplacement;
                Debug.Log(instanceFireBall.position);

                if (instanceFireBall.position.x - spell.Value.transform.position.x < 0.1f)
                {
                    List<GameObject> fireBallFx = mDictionaryFX.getValueFromKey("FireBall");
                    Debug.Log(instanceFireBall.position);

                    foreach (GameObject fx in fireBallFx)
                    {
                        if (fx.name == "Explosion")
                        {
                            Debug.Log(instanceFireBall.position);
                            spell.Value.transform.localScale = new Vector3(((Circle)spell.Key).mSizeAOE, 0.01f, ((Circle)spell.Key).mSizeAOE);
                            instanceExplosion = Instantiate(fx, instanceFireBall.position, instanceFireBall.rotation) as GameObject;
                            instanceExplosion.transform.parent = spell.Value.gameObject.transform;
                        }
                    }

                }
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
