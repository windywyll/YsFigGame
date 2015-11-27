using UnityEngine;
using System.Collections;

public class OnCollisionEnterLine : MonoBehaviour
{
    private string mNameSpell;

    void OnTriggerStay(Collider other)
    {
        Vector3 posChild;
        Player player = other.gameObject.GetComponent<Player>();

        posChild = this.gameObject.transform.GetChild(0).position;
        if (player == null)
        {
            return;
        }
        if (other.bounds.Contains(posChild))
        {
            this.gameObject.transform.parent.gameObject.GetComponent<Player>().spellHasHit(mNameSpell, player);
        }
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
