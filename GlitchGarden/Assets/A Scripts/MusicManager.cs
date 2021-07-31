using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
	public AudioClip[] levelMusicChangeArray;
	private AudioSource audioSource;

	void Awake()
	{
		DontDestroyOnLoad(this);

	}

	void Start()
	{
		audioSource = GetComponent<AudioSource>();
		audioSource.volume = PlayerPrefsController.GetMasterVolume();
	}
	/*
	void OnLevelWasLoaded(int level)
	{
		AudioClip thisLevelMusic = levelMusicChangeArray[level];
		Debug.Log("Playing clip: " + thisLevelMusic);

		if (thisLevelMusic)
		{ // If there's some music attached
			audioSource.clip = thisLevelMusic;
			audioSource.loop = true;
			audioSource.Play();
		}
	}*/

	public void SetVolume(float volume)
	{
		audioSource = GetComponent<AudioSource>();
		audioSource.volume = volume;
	}
}
