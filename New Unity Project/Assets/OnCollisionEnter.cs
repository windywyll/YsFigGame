using UnityEngine;
using System.Collections;

public class OnCollisionEnter : MonoBehaviour
{
    public void onTriggerEnter(Collider other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if (player == null)
        {
            return;
        }
    }
}
