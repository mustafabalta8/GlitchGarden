using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizard : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Defender"))
        {
            GetComponent<Attacker>().AttackStatu(otherCollider.gameObject, true);
        }
        
    }
    private void OnTriggerExit2D(Collider2D otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Defender"))
        {
            GetComponent<Attacker>().AttackStatu(otherCollider.gameObject, false);
        }
    }
}
