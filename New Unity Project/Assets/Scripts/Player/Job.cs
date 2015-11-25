using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Job : MonoBehaviour
{
    private string mName;
    private List<Spell> mSpellsPossibles;

    internal abstract void modifStats();
}
