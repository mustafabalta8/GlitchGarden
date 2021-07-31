using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;

    [SerializeField] Text DifText;
    MusicManager musicManager;


    private void Start()
    {
        DifText.text = "difficulty ->   " + PlayerPrefsController.GetDifficulty();
        musicManager = FindObjectOfType<MusicManager>();
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
    }

    private void Update()
    {
        /*var musicPlayer = FindObjectOfType<MusicManager>();
        if (musicPlayer)
        {
            musicPlayer.SetVolume(volumeSlider.value);
        }
        else
        {
            Debug.LogWarning("no music player");
        }*/
    }
    public void ChangeVolumeOnSliderValueChange()
    {
        musicManager.SetVolume(volumeSlider.value);
    }

    public void SaveVolume()
    {
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);

    }
    public void SetDifficulty(string difLevel)
    {
        PlayerPrefsController.SetDifficulty(difLevel);
        DifText.text = "difficulty ->   " + PlayerPrefsController.GetDifficulty();

    }
}
