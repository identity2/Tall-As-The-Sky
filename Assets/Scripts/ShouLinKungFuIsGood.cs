using UnityEngine;
using System.Collections;

public class ShouLinKungFuIsGood : MonoBehaviour
{
	public SpriteRenderer sr;

	public Sprite invincible; //iron head -> invincible
	public Sprite useless;    //golden legs -> useless

	public GameObject ironHeadHitAudio;

	private int blockingTimesLeft;

	private const int TotalBlockingTimes = 10;
	private const float MinAlphaVal = 0.5f;

	void Start()
	{
		if (Random.value >= .5f) { //iron head

			//change sprite
			sr.sprite = invincible;

			//initialize blocking times
			blockingTimesLeft = TotalBlockingTimes;

			//disable Collider 2D for the Player (so that the player can't be hurt)
			GameObject.FindGameObjectWithTag ("Player").GetComponent<Collider2D> ().enabled = false;

		} else { //golden legs

			//change sprite
			sr.sprite = useless;

			//disable Collider 2D for the weapon
			GetComponent<Collider2D> ().enabled = false;
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Enemy" || col.gameObject.tag == "Enemy Bullet") {

			//destroy enemy/enemy bullet
			Destroy (col.gameObject);

			//audio
			Instantiate (ironHeadHitAudio, Vector2.zero, Quaternion.identity);

			//decrease blocking times by 1
			blockingTimesLeft--;

			//if no more blocking times, reenble Collider 2D for Player
			if (blockingTimesLeft == 0) {
				GameObject.FindGameObjectWithTag ("Player").GetComponent<Collider2D> ().enabled = true;

				Destroy (gameObject);
			} else {

				//increase transparency (aka. decrease alpha value)
				sr.color = new Color (sr.color.r, sr.color.g, sr.color.b, MinAlphaVal + (1f - MinAlphaVal) * (float)blockingTimesLeft / (float)TotalBlockingTimes);
			}
		}
	}

}
