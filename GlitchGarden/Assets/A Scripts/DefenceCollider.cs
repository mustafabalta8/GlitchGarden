using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenceCollider : MonoBehaviour
{
    Lives lives;
    // Start is called before the first frame update
    void Start()
    {
        lives = GetComponent<Lives>();
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        lives.DecreareLives();

        Destroy(otherCollider.gameObject);
    }
}
