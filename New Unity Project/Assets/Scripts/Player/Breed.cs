using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Breed : MonoBehaviour
{
    private string mName;
    private List<Job> mJobsPossibles;
    private List<Spell> mSpellsPossibles;

    internal abstract void modifStats();
}
