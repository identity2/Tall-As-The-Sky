using UnityEngine;
using System.Collections;

public class RandomInitialSpeed : MonoBehaviour
{
	public Vector3 minSpeed;
	public Vector3 maxSpeed;

	private Vector3 speed;

	void Start()
	{
		speed = new Vector3 (Random.Range (minSpeed.x, maxSpeed.x), Random.Range (minSpeed.y, maxSpeed.y));
	}

	void Update()
	{
		transform.Translate (speed * Time.deltaTime);
	}
}
