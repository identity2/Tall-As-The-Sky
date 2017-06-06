using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonClickSound : MonoBehaviour 
{
	public GameObject clickSound;

	void Start()
	{
		GetComponent<Button> ().onClick.AddListener (() => {
			ButtonClicked ();
		});
	}

	void ButtonClicked()
	{
		//DontDestroyOnLoad because button click sounds should last between scenes
		DontDestroyOnLoad((Instantiate (clickSound, Vector2.zero, Quaternion.identity) as GameObject));
	}
}
