using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
	public float movementSpeed;

	//player movement boundaries
	public float minPosX;
	public float maxPosX;

	private float midScreenPosX;

	void Start()
	{
		//initialize the mid point of the screen
		midScreenPosX = Screen.width / 2f;
	}

	void Update () 
	{
		float movement = 0f;

		//keyboard controlled movement
		movement = Input.GetAxis ("Horizontal") * movementSpeed * Time.deltaTime;


		//touch control (overrides keyboard control)
		if (Input.touchCount > 0) {
			Touch touch = Input.GetTouch (0);
			movement = (touch.position.x < midScreenPosX ? -1f : 1f) * movementSpeed * Time.deltaTime;
		}

		//update the new position of player
		Vector3 newPos = new Vector3 (Mathf.Clamp(transform.position.x + movement, minPosX, maxPosX), transform.position.y, transform.position.z);
		transform.position = newPos;
	}
}
