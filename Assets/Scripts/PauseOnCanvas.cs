using UnityEngine;
using System.Collections;

public class PauseOnCanvas : MonoBehaviour 
{
	void OnEnable()
	{
		Time.timeScale = 0f;
	}

	void OnDisable()
	{
		Time.timeScale = 1f;
	}
}
