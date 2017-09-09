using UnityEngine;
using System.Collections;

public class PauseBackgroundMusicOnCanvas : MonoBehaviour 
{
	private AudioSource bgMusicAudioSource;

	void OnEnable()
	{
		bgMusicAudioSource = GameObject.FindGameObjectWithTag ("Background Music").GetComponent<AudioSource> ();

		bgMusicAudioSource.Pause ();
	}

	void OnDisable()
	{
		bgMusicAudioSource.UnPause ();
	}
}
