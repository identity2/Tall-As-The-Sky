using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LinkToURLOnClick : MonoBehaviour 
{
	public string url;

	void Start()
	{
		GetComponent<Button> ().onClick.AddListener (() => {
			ButtonClicked ();
		});
	}

	void ButtonClicked()
	{
		Application.OpenURL (url);
	}
}
