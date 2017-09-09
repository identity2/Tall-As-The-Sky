using UnityEngine;
using System.Collections;

public class SpawnBullet : MonoBehaviour 
{
	public GameObject bulletPrefab;
	public float interval;
	public bool followMovement; //if the bullet follows the movement of Player

	public GameObject shootAudio = null;

	public Animator shootAnim = null;
	private const float AnimationDelay = 0.2f; //to solve visual incosistency

	void Start()
	{
		StartCoroutine (SpawnCoroutine ());
	}

	IEnumerator SpawnCoroutine()
	{
		while (true) {

			//shoot animation
			if (shootAnim != null)
				shootAnim.SetTrigger ("Shoot");
			
			yield return new WaitForSeconds (AnimationDelay);

			//instantiate bullet
			GameObject bullet = (Instantiate (bulletPrefab, new Vector3 (transform.position.x, transform.position.y, 0.1f), Quaternion.identity) as GameObject);

			//shoo audio
			if (shootAudio != null)
				Instantiate (shootAudio, Vector2.zero, Quaternion.identity);

			if (followMovement)
				bullet.transform.parent = transform;

			//wait for next shoot
			yield return new WaitForSeconds (interval - AnimationDelay);
		}
	}
}
