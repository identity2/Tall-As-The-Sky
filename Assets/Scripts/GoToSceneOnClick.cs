using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoToSceneOnClick : MonoBehaviour 
{
	public int sceneIndex;

	void Start()
	{
		GetComponent<Button> ().onClick.AddListener (() => {
			ClickEvent ();
		});
	}

	void ClickEvent()
	{
		SceneManager.LoadScene (sceneIndex);
	}
}
