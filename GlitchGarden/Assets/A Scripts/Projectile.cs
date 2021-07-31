using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{


    [SerializeField] int damage;

    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * 5);//

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Attacker>().DecreaseHealth(damage);

        }
        Destroy(gameObject);

    }
}