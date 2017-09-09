using UnityEngine;
using System.Collections;

public class ChangeBackgroundMusicPitchOnStart : MonoBehaviour 
{
	public float pitch;

	void Start()
	{
		AudioSource source = GameObject.FindGameObjectWithTag ("Background Music").GetComponent<AudioSource> ();
		source.Stop ();
		source.pitch = pitch;
		source.Play ();
	}
}
