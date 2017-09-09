using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DestroyCanvasOnClick : MonoBehaviour 
{
	public GameObject canvas;	

	void Start()
	{
		GetComponent<Button> ().onClick.AddListener (() => {
			ClickEvent ();
		});
	}

	void ClickEvent()
	{
		Destroy (canvas);
	}
}
