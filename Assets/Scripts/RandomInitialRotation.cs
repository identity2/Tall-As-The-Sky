using UnityEngine;
using System.Collections;

public class RandomInitialRotation : MonoBehaviour 
{
	void Start()
	{
		transform.rotation = Quaternion.Euler (0f, 0f, Random.Range (0f, 359f));
	}
}
