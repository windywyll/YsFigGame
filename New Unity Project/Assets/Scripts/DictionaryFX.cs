using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DictionaryFX : MonoBehaviour
{
    public Dictionary<string, List<GameObject>> mDictionaryFX;

    public GameObject Aura;
    public GameObject FireBall;
    public GameObject Explosion;
    public GameObject Heal;
    public GameObject MagicShoot;

    public GameObject Bolas;
    public GameObject Stun;
    public GameObject Hit;
    public GameObject Uppercut;
    public GameObject Sprint;

    void Start()
    {
        List<GameObject> fireAuraFX = new List<GameObject>();
        fireAuraFX.Add(Aura);
        List<GameObject> fireBallFX = new List<GameObject>();
        fireBallFX.Add(FireBall);
        fireBallFX.Add(Explosion);
        List<GameObject> healFX = new List<GameObject>();
        healFX.Add(Heal);
        List<GameObject> magicShootFX = new List<GameObject>();
        magicShootFX.Add(MagicShoot);

        List<GameObject> bolasFX = new List<GameObject>();
        bolasFX.Add(Bolas);
        bolasFX.Add(Stun);
        List<GameObject> hitFX = new List<GameObject>();
        hitFX.Add(Hit);
        List<GameObject> uppercutFX = new List<GameObject>();
        uppercutFX.Add(Uppercut);
        List<GameObject> sprintFX = new List<GameObject>();
        uppercutFX.Add(Sprint);
        
        mDictionaryFX = new Dictionary<string, List<GameObject>>();
        mDictionaryFX.Add("FireAura", fireAuraFX);
        mDictionaryFX.Add("FireBall", fireBallFX);
        mDictionaryFX.Add("MinorHeal", healFX);
        mDictionaryFX.Add("MagicShoot", magicShootFX);

        mDictionaryFX.Add("Bolas", bolasFX);
        mDictionaryFX.Add("Hit", hitFX);
        mDictionaryFX.Add("Uppercut", uppercutFX);
        mDictionaryFX.Add("Sprint", sprintFX);
    }

    public List<GameObject> getValueFromKey(string name)
    {
        foreach (KeyValuePair<string, List<GameObject>> nameFX in mDictionaryFX)
        {
            if(name == nameFX.Key)
            {
                return nameFX.Value;
            }
        }
        return null;
    }
}
