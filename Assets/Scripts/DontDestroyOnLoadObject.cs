using UnityEngine;
using System.Collections;

public class DontDestroyOnLoadObject : MonoBehaviour 
{
	void Start()
	{
		DontDestroyOnLoad (gameObject);
	}
}
