using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayMovieOnStartAndGoToScene : MonoBehaviour 
{
	public int goToSceneAfterMovie;

	void Start()
	{
		StartCoroutine (AnimationCoroutine ());
	}

	IEnumerator AnimationCoroutine()
	{
		Handheld.PlayFullScreenMovie ("Intro Animation.mov");
		yield return new WaitForEndOfFrame ();

		//after playing the movie, go to game scene
		SceneManager.LoadScene (goToSceneAfterMovie);
	}
}
