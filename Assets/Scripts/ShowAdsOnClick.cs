using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class ShowAdsOnClick : MonoBehaviour
{
	void Start()
	{
		GetComponent<Button> ().onClick.AddListener (() => {
			ButtonClicked ();
		});
	}

	void ButtonClicked()
	{
		if (Advertisement.IsReady ()) {
			Advertisement.Show ();
		}
	}
}
