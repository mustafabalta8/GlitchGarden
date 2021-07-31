using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    Attacker attacker;
    // Start is called before the first frame update
    void Start()
    {
        attacker = GetComponent<Attacker>();
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.gameObject.name == "Gravestone(Clone)")
        {
            GetComponent<Animator>().SetTrigger("Jump");
        }
        else if (otherCollider.gameObject.CompareTag("Defender"))
        {
            attacker.AttackStatu(otherCollider.gameObject, true);
        }
        
    }
    private void OnTriggerExit2D(Collider2D otherCollider)
    {
        if (otherCollider.gameObject.name == "Gravestone(Clone)")
        {
            GetComponent<Animator>().SetTrigger("Jump");
        }
        else if (otherCollider.gameObject.CompareTag("Defender"))
        {
            attacker.AttackStatu(otherCollider.gameObject, false);
        }
    }
}
