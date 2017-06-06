using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverCanvas : MonoBehaviour
{
	public Text finalScoreText;
	public Image buildingImage;

	public Sprite[] buildingSprites;
	public int[] buildingHeights;

	private int score;

	void Start()
	{
		score = GameObject.FindObjectOfType<ScoreText> ().CurrScore;

		finalScoreText.text = score.ToString() + "cm";

		int spriteIndex = 0;
		while (spriteIndex < buildingHeights.Length && buildingHeights [spriteIndex] < score) {
			spriteIndex++;
		}

		buildingImage.sprite = buildingSprites [spriteIndex - 1];

		//save data
		ScoreBoardDataControl.instance.NewScore (GameObject.FindObjectOfType<Character> ().charIndex, score);
	}

}
