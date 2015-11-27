using UnityEngine;
using System.Collections;

public class OnCollisionEnter : MonoBehaviour
{
    private string mNameSpell;

    void OnTriggeeEnter(Collider other)
    {
    }

    public void setNameSpell(string spell)
    {
        mNameSpell = spell;
    }

    public string getNameSpell()
    {
        return mNameSpell;
    }
}
