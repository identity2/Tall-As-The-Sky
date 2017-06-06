using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImageByLanguage : MonoBehaviour
{
	public Sprite chinese;
	public Sprite english;
	
	void Start()
		{
			Image image = GetComponent<Image>();

			if (Application.systemLanguage == SystemLanguage.Chinese ||
				Application.systemLanguage == SystemLanguage.ChineseSimplified ||
				Application.systemLanguage == SystemLanguage.ChineseTraditional)
			{
				image.sprite = chinese;
			}
			else
			{
				image.sprite = english;
			}
		}
}
