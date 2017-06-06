using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InstantiateCanvasOnClick : MonoBehaviour 
{
	public GameObject canvasPrefab;

	void Start()
	{
		GetComponent<Button> ().onClick.AddListener (() => {
			ClickEvent ();
		});
	}

	void ClickEvent()
	{
		Instantiate (canvasPrefab, Vector2.zero, Quaternion.identity);
	}
}
