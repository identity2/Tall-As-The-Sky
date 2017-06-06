using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SetActiveOnClick : MonoBehaviour
{
	public GameObject go;

	void Start()
	{
		GetComponent<Button>().onClick.AddListener(()=> {
			ButtonClicked();
		});
	}

	void ButtonClicked()
	{
		go.SetActive (true);
	}
}
