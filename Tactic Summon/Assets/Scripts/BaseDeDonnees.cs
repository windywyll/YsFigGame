using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BaseDeDonnees : MonoBehaviour
{
    List<Player> mPrefabsPlayer;

    void Start()
    {
        DontDestroyOnLoad(this);
    }


}
