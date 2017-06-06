using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTextByLanguage : MonoBehaviour 
{
	public string chinese;
	public string english;

	void Start()
	{
		Text text = GetComponent<Text>();

		if (Application.systemLanguage == SystemLanguage.Chinese ||
			Application.systemLanguage == SystemLanguage.ChineseSimplified ||
			Application.systemLanguage == SystemLanguage.ChineseTraditional)
		{
			text.text = chinese;
		}
		else
		{
			text.text = english;
		}
	}
}
