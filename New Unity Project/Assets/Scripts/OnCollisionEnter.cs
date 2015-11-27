using UnityEngine;
using System.Collections;

public class OnCollisionEnter : MonoBehaviour
{
    private string mNameSpell;

    void OnTriggerEnter(Collider other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if (player == null)
        {
            return;
        }
        this.gameObject.transform.parent.gameObject.GetComponent<Player>().spellHasHit(mNameSpell, player);
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
