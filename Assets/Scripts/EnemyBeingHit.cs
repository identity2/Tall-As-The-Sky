using UnityEngine;
using System.Collections;

public class EnemyBeingHit : MonoBehaviour 
{
	public GameObject dieAnimation = null;
	public Transform bulletAnimationPos; //the position to instantiate bullet hit animation

	public void BeingHit()
	{
		if (dieAnimation != null)
			Instantiate (dieAnimation, transform.position, Quaternion.identity);

		Destroy (gameObject);
	}
}
