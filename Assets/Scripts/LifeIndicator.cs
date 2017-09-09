using UnityEngine;
using System.Collections;

public class LifeIndicator : MonoBehaviour
{
	public GameObject[] lifeImages;
	public GameObject gameOverCanvasPrefab;
	public GameObject dieAudio;

	private int currentLife;

	void Start()
	{
		currentLife = lifeImages.Length;
	}

	public void DecreaseLife()
	{
		currentLife--;
		lifeImages [currentLife].SetActive (false);

		if (currentLife == 0) {
			Instantiate (gameOverCanvasPrefab, Vector2.zero, Quaternion.identity);
			Instantiate (dieAudio, Vector2.zero, Quaternion.identity);
		}
	}
}
