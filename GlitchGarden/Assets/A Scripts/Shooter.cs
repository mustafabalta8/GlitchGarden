using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject Projectile, ProjectileInitialLocation;

    GameObject ProjectileHolder;


    AttackerSpawner myLaneSpawner;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        ProjectileHolder = GameObject.Find("ProjectileHolder");
        animator = GetComponent<Animator>();

        SetLaneSpawner();

    }
    private void Update()
    {
       // SetLaneSpawner();
        if (IsAttackerInLane())
        {
            //shooting anim
            animator.SetBool("IsAttacking", true);

        }
        else
        {
            //idle anim
            animator.SetBool("IsAttacking", false);
        }
    }
    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();
        foreach(AttackerSpawner spawner in spawners)
        {
           //Debug.Log("spawner.transform.position.y: " + spawner.transform.position.y + "\ntransform.position.y:" + transform.position.y);
           // Debug.Log("result of process:" + (spawner.transform.position.y - transform.position.y));
            bool IsCloseEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y)  <= 0.42f && Mathf.Abs(spawner.transform.position.y - transform.position.y) >= 0.38f );// Mathf.Epsilon research
           // Debug.Log(spawner.name+" IsCloseEnough:" + IsCloseEnough);
            if (IsCloseEnough)
                myLaneSpawner = spawner;
        }
    }

    private bool IsAttackerInLane()
    {
        
        if(myLaneSpawner.transform.childCount <= 0 )
        {
            return false;
        }
        else
        {
            return true;
        }

    } 

    public void Fire()
    {
        GameObject ProjectileObj = Instantiate(Projectile, ProjectileInitialLocation.transform.position, transform.rotation, ProjectileHolder.transform);//, ProjectileHolder.transform
        //ProjectileObj.transform.Translate(Vector2.right * Time.deltaTime);
    }


}
