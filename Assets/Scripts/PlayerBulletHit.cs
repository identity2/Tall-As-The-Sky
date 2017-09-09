using UnityEngine;
using System.Collections;

public class PlayerBulletHit : MonoBehaviour 
{
	public GameObject hitAnimation = null;
	public GameObject hitAudio = null;

	public bool destroySelf; //is the bullet reusable?

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Enemy Bullet") {
			Destroy (col.gameObject); //destroy enemy bullet

			if (destroySelf)
				Destroy (gameObject);
			
		} else if (col.gameObject.tag == "Enemy") {
			EnemyBeingHit enemyData = col.gameObject.GetComponent<EnemyBeingHit>();

			//instantiate hit animation
			if (hitAnimation != null)
				Instantiate (hitAnimation, enemyData.bulletAnimationPos.position, Quaternion.identity);

			//hit audio
			if (hitAudio != null)
				Instantiate (hitAudio, Vector2.zero, Quaternion.identity);

			//inform the enemy that it has been hit
			col.gameObject.GetComponent<EnemyBeingHit> ().BeingHit ();

			if (destroySelf)
				Destroy (gameObject);
		}
	}

}
