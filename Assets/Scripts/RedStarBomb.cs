using UnityEngine;
using System.Collections;

public class RedStarBomb : MonoBehaviour 
{
	public GameObject collapsePrefab;
	public float seconds;

	void Start()
	{
		Invoke ("Collapse", seconds);
	}

	void Collapse()
	{
		Instantiate (collapsePrefab, transform.position, Quaternion.identity);
		Destroy (gameObject);
	}
}
