using UnityEngine;
using System.Collections;

public class RandomInitialLocalScale : MonoBehaviour 
{
	public float minVal;
	public float maxVal;

	void Start()
	{
		transform.localScale = transform.localScale * Random.Range (minVal, maxVal);
	}
}
