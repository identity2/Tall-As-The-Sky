using UnityEngine;
using System.Collections;

public class ChangeSpriteRepeatedly : MonoBehaviour 
{
	public float interval;
	public float duration;

	public Sprite initialSprite;
	public Sprite otherSprite;

	private SpriteRenderer sr { get { return GetComponent<SpriteRenderer> (); } }

	void Start()
	{
		StartCoroutine (ChangeSpriteCoroutine ());
	}

	IEnumerator ChangeSpriteCoroutine()
	{
		while (true) {
			sr.sprite = initialSprite;
			yield return new WaitForSeconds (duration);

			sr.sprite = otherSprite;
			yield return new WaitForSeconds (interval - duration);
		}
	}
}
