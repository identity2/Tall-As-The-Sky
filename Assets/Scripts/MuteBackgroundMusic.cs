using UnityEngine;
using System.Collections;

public class MuteBackgroundMusic : MonoBehaviour 
{
	private float originalVolume;
	private AudioSource backgroundAudioSource;

	void OnEnable()
	{
		backgroundAudioSource = GameObject.FindGameObjectWithTag ("Background Music").GetComponent<AudioSource> ();
		originalVolume = backgroundAudioSource.volume;
		backgroundAudioSource.volume = 0f;
	}

	void OnDisable()
	{
		backgroundAudioSource.volume = originalVolume;
	}
}
