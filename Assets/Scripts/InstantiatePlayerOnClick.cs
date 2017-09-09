using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InstantiatePlayerOnClick : MonoBehaviour
{
	public GameObject playerPrefab;
	public Vector3 instantiatePos;
	public GameObject currCanvas;

	void Start()
	{
		GetComponent<Button> ().onClick.AddListener (() => {
			ClickEvent ();
		});
	}

	void ClickEvent()
	{
		Instantiate (playerPrefab, instantiatePos, Quaternion.identity);
		Destroy (currCanvas);
	}
}
