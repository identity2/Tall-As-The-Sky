using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
	public int initialScore;
	public int addScorePerSec;

	private int currScore;
	public int CurrScore {
		get {
			return currScore;
		}
	}

	void Start()
	{
		currScore = initialScore;

		InvokeRepeating ("AddScoreAndDisplay", 1f, 1f);
	}

	//increase score every second
	void AddScoreAndDisplay()
	{
		currScore += addScorePerSec;
		GetComponent<Text> ().text = currScore.ToString() + "cm";
	}
}