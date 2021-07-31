using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(0f, 5f)] [SerializeField] float walkSpeed;
    [SerializeField] int health;

    [SerializeField] GameObject DeathVFX;
    [SerializeField] GameObject VFXHolder;

    GameObject currentTarget;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * walkSpeed);                //using time.deltaTime to make frame rate independet
    }

    public void SetMovementSpeed(float speed)
    {
        walkSpeed = speed;
    }
    public void DecreaseHealth(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
           
            GameObject DeathVFXObject = Instantiate(DeathVFX, transform.position, transform.rotation);// VFXHolder.transform
            Destroy(DeathVFXObject, 1f);

            FindObjectOfType<LevelController>().numberOfAttackers(-1);

            Destroy(gameObject);

        }

    }
    public void AttackStatu(GameObject target, bool Attacking)
    {
        if (Attacking)
        {
            GetComponent<Animator>().SetBool("IsAttacking", true);
            currentTarget = target;
        }

        if (!Attacking)
        {
            GetComponent<Animator>().SetBool("IsAttacking", false);
        }
    }

    public void StrikeCurrentTarget(int damage)
    {
        if (!currentTarget) { return; }

        currentTarget.gameObject.GetComponent<Defender>().DecreaseHealth(damage);


    }
}
