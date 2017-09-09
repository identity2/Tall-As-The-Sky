using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreboardScoreText : MonoBehaviour 
{
	public int place;

	void Start()
	{
		int score = ScoreBoardDataControl.instance.GetScore (place);
		if (score != 0) {
			GetComponent<Text> ().text = score.ToString () + "cm";
		} else {
			gameObject.SetActive (false);
		}
	}
}
