using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayMovieOnClick : MonoBehaviour
{
	void Start()
	{
		GetComponent<Button> ().onClick.AddListener (() => {
			Handheld.PlayFullScreenMovie ("Intro Animation.mov");
		});
	}
}
