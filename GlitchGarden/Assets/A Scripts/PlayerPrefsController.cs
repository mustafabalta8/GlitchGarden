using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    const string MASTER_VOLUME_KEY = "masterVolume";
    const string DIFFICULTY_KEY = "difficulty";

    const float minVolume = 0f;
    const float maxVolume = 1f;

    public static void SetMasterVolume(float volume)
    {
        if(volume >= minVolume && volume <= maxVolume)
        {
            //Debug.Log("master volume set to" + volume);
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }
        else
        {
            Debug.LogError("master volume is out of range");
        }
        
    }

    public static float GetMasterVolume()
    {       
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static void SetDifficulty(string difLevel)
    {
        PlayerPrefs.SetString(DIFFICULTY_KEY, difLevel);
    }
    public static string GetDifficulty()
    {
        return PlayerPrefs.GetString(DIFFICULTY_KEY);
    }
}
