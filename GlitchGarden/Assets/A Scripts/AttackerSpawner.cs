using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] float minTime, maxTime;
  
    [SerializeField] Attacker[] AttackerObjs;
    bool spawn = true;
    int i;
    bool makeOneDecreaseOnMaxTime=false;

    [SerializeField] int StartOfFinalAttackWave;
    [SerializeField] int EndOfWawe;
    LevelController levelController;
    /*void Start()
    {
        if (spawn)
        {
            StartCoroutine(Spawn());
        }
    }*/
    IEnumerator Start()
    {
        makeOneDecreaseOnMaxTime = false;
        levelController = FindObjectOfType<LevelController>();
        while (spawn)
        {
            yield return StartCoroutine(Spawn());
            
        }
        
    }

    IEnumerator Spawn()
    {
        Debug.Log(Time.timeSinceLevelLoad + "Time.timeSinceLevelLoad");

        if (Time.timeSinceLevelLoad > StartOfFinalAttackWave && Time.timeSinceLevelLoad < EndOfWawe)
        {
            Debug.Log(gameObject.name + "max min =1 if calýþtý");
            minTime = 1;
            maxTime = 1;
        }
        else if (Time.timeSinceLevelLoad> EndOfWawe)
        {
            minTime = 3;
            maxTime = 10;
            Debug.Log(gameObject.name + "max  10 min =3 if calýþtý");
        }

            yield return new WaitForSeconds(Random.Range(minTime, maxTime));

        i++;
        Debug.Log(gameObject.name + i + "tane spawn edildi");

        Debug.Log(gameObject.name + "max: " + maxTime+" \nmin: "  + minTime);

        if (Time.timeSinceLevelLoad < StartOfFinalAttackWave && makeOneDecreaseOnMaxTime==false)
        {
            minTime -= 0.5f;
            maxTime -= 3;
            Debug.Log(gameObject.name+"new max time: " + maxTime);
            Debug.Log("new max time: " + maxTime);
            makeOneDecreaseOnMaxTime = true;
        }
        

        int selectedAttacker = Random.Range(0, 2);
        Instantiate(AttackerObjs[selectedAttacker], transform.position+new Vector3(0, -0.2f), transform.rotation,transform);

        levelController.numberOfAttackers(1);

        makeOneDecreaseOnMaxTime = false;
    }
    public void StopSpawning()
    {
        spawn = false;
    }

  


}
