using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShareButton : MonoBehaviour 
{
	private string shareText;

	void Start()
	{
		shareText = "我在「我要和天一樣高！」長了" + GameObject.FindObjectOfType<ScoreText> ().CurrScore.ToString() + "公分......差點就要和天一樣高了！！！";

		GetComponent<Button> ().onClick.AddListener (() => {
			ButtonClicked ();
		});
	}

	void ButtonClicked()
	{
		GetComponent<NativeShare> ().ShareScreenshotWithText (shareText);
	}
}
