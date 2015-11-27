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
            Debug.Log("1_  "+spell.Key.mName);
            if(spell.Key.mName == "FireBall")
            {
                Vector3 deplacement = ((Circle)spell.Key).mStep * Time.deltaTime;
                spell.Value.transform.position += deplacement;
                Debug.Log("2_  " +  (( (Circle)spell.Key ).targetFX - spell.Value.transform.position));
                Debug.Log("3_  " + (((Circle)spell.Key).targetFX - spell.Value.transform.position).magnitude);
                if(  (((Circle)spell.Key).targetFX - spell.Value.transform.position).magnitude < 0.01f)
                {
                    Debug.Log("4_  " + spell.Key.mName);
                    List<GameObject> fireAuraFx = mDictionaryFX.getValueFromKey("FireAura");
                    GameObject instanceFx;

                    foreach(GameObject fx in fireAuraFx)
                    {
                        Debug.Log("5_  " + fx.name);
                        if(fx.name == "Explosion")
                        {
                            Debug.Log("Create Explosion");
                            instanceFx = Instantiate(fx, transform.position, transform.rotation) as GameObject;
                            instanceFx.transform.parent = spell.Key.gameObject.transform;
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
