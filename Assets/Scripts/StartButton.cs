using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour 
{
	public int movieScene;
	public int playScene;

	void Start()
	{
		GetComponent<Button> ().onClick.AddListener (() => {
			ButtonClicked ();
		});
	}

	void ButtonClicked()
	{
		if (ScoreBoardDataControl.instance.GetScore (0) > 0) {
			SceneManager.LoadScene (playScene);
		} else {
			SceneManager.LoadScene (movieScene);
		}
	}
}
