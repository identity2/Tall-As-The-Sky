using UnityEngine;
using System.Collections;

public class WeaponSpawn : MonoBehaviour
{
	public GameObject[] weaponPrefabs;

	//spawn position
	public float posY;
	public float minPosX;
	public float maxPosX;

	//spawn interval
	public float minInterval;
	public float maxInterval;

	void Start()
	{
		StartCoroutine (SpawnCoroutine ());
	}

	IEnumerator SpawnCoroutine()
	{
		while (true) {
			//instantiate random falling weapon
			Instantiate (weaponPrefabs [Random.Range (0, weaponPrefabs.Length)], new Vector3 (Random.Range (minPosX, maxPosX), posY, -0.1f), Quaternion.identity);

			//wait for next spawn
			yield return new WaitForSeconds (Random.Range (minInterval, maxInterval));
		}
	}
}
