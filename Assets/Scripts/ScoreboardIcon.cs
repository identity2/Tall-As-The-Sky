using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreboardIcon : MonoBehaviour 
{
	public int place;

	public Sprite[] characterTypes;

	void Start()
	{
		int charType = ScoreBoardDataControl.instance.GetPlayerType (place);
		if (charType != -1) {
			GetComponent<Image> ().sprite = characterTypes [charType];
		} else {
			gameObject.SetActive (false);
		}
	}
}
