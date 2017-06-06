using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour
{
	public int charIndex;

	public GameObject beingHitAudio;

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Enemy" || col.gameObject.tag == "Enemy Bullet") {

			//hurt animation
			GetComponent<Animator> ().SetTrigger ("Sad");

			//hurt audio
			Instantiate (beingHitAudio, Vector2.zero, Quaternion.identity);

			//decrease life
			GameObject.FindObjectOfType<LifeIndicator> ().DecreaseLife ();

			//destroy Enemy/Enemy Bullet
			Destroy (col.gameObject);
		}
	}

	public void GetWeapon()
	{
		GetComponent<Animator> ().SetTrigger ("Happy");
	}
}
