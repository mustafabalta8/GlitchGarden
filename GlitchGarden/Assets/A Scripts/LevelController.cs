using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    
    [SerializeField] int NumberOfAliveAttackers;
    bool levelTimerFinished;
    bool GameEnded;

    [SerializeField] GameObject NextLevelPanel;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        levelTimerFinished = false;
        GameEnded = false;

    }
    void Update()
    {

        if (levelTimerFinished == true && NumberOfAliveAttackers <= 0 && GameEnded ==false)
        {
            audioSource.Play();
            Debug.Log("game end");
            Time.timeScale = 0;
            NextLevelPanel.SetActive(true);
            GameEnded = true;
        }


    }
   
    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        stopSpawners();
    }

    public void numberOfAttackers(int change)
    {
        NumberOfAliveAttackers += change;
        //Debug.Log("NumberOfAliveAttackers" + NumberOfAliveAttackers);
    }
    private void stopSpawners()
    {
        AttackerSpawner[] attackerSpawners = FindObjectsOfType<AttackerSpawner>();
        foreach(AttackerSpawner spawner in attackerSpawners)
        {
            spawner.StopSpawning();
        }
    }

    

    
}
