using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChangeImageByIndex : MonoBehaviour
{
	public Sprite[] charSprites;

	public void Start()
	{
		GetComponent<Image> ().sprite = charSprites[GameObject.FindObjectOfType<Character> ().charIndex];
	}
}
