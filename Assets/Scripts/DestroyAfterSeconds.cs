using UnityEngine;
using System.Collections;

public class DestroyAfterSeconds : MonoBehaviour
{
	public float second;

	void Start()
	{
		Invoke ("DestroyGameObject", second);
	}

	void DestroyGameObject()
	{
		Destroy (gameObject);
	}
}
