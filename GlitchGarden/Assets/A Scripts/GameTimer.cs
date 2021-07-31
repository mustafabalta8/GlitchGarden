using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{

    [Tooltip("Level Timer in Seconds")]
    [SerializeField] float levelTime = 10;
    bool levelFinished;

   
   // bool FinalAttackWave;

   // AttackerSpawner[] attackerSpawners;
    LevelController levelController;
    Slider slider;

   // [SerializeField]int i=0;
    private void Start()
    {
        //FinalAttackWave = false;
        levelFinished = false;
        slider = GetComponent<Slider>();
        levelController = FindObjectOfType<LevelController>();
      //  attackerSpawners = FindObjectsOfType<AttackerSpawner>();
        
    }
    private void Update()
    {
        if (levelFinished) { return; }
        slider.value = Time.timeSinceLevelLoad / levelTime;

        /*if (Time.timeSinceLevelLoad >= 20 && FinalAttackWave==false)
        {
            foreach (AttackerSpawner spawner in attackerSpawners)
            {
                spawner.SetMaxAndMinTime(1f, 1f);
                i++;
            }
           
            Invoke("SetFinalWave", 5);
           
            FinalAttackWave = true;
        }*/

        if (Time.timeSinceLevelLoad >= levelTime)
        {
            levelController.LevelTimerFinished();
            levelFinished = true;
        }
        
    }
    /*
    private void SetFinalWave()
    {

        foreach (AttackerSpawner spawner in attackerSpawners)
        {
            spawner.SetMaxAndMinTime(8f, 20);
        }
    }*/
}
