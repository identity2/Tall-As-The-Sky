using UnityEngine;
using System.Collections;

public class EnemySpawnPoint : MonoBehaviour 
{
	//interval between to enemy spawns
	public float minSpawnInterval;
	public float maxSpawnInterval;

	//after "decreaseTime", "minSpawnInterval" and "maxSpawnInterval" would be reduced to make the game harder
	public float minSpawnIntervalDecreaseRate;
	public float maxSpawnIntervalDecreaseRate;
	public float decreaseTime;

	//the minimal interval to spawn enemy
	public float minSpawnIntervalCap;
	public float maxSpawnIntervalCap;

	//three levels of enemies
	public GameObject[] tier1EnemyPrefabs;
	public GameObject[] tier2EnemyPrefabs;
	public GameObject[] tier3EnemyPrefabs;

	//the time to change from tier1 enemy to tier2 enemy
	public float secToTier2;

	//the time to change from tier2 enemy to tier3 enemy
	public float secToTier3;

	private GameObject[] currEnemyPrefabs;

	void Start()
	{
		StartCoroutine (ChangeEnemyTierCoroutine ());
		StartCoroutine (SpawnCoroutine ());
		StartCoroutine (DecreaseSpawnIntervalCoroutine ());
	}

	//change enemy tiers
	IEnumerator ChangeEnemyTierCoroutine()
	{
		currEnemyPrefabs = tier1EnemyPrefabs;

		yield return new WaitForSeconds (secToTier2);

		currEnemyPrefabs = tier2EnemyPrefabs;

		yield return new WaitForSeconds (secToTier3);

		currEnemyPrefabs = tier3EnemyPrefabs;
	}

	//spawns enemies
	IEnumerator SpawnCoroutine()
	{
		while (true) {
			yield return new WaitForSeconds (Random.Range (minSpawnInterval, maxSpawnInterval));

			Instantiate (currEnemyPrefabs [Random.Range (0, currEnemyPrefabs.Length)], transform.position, Quaternion.identity);
		}
	}

	//decrease spawn interval
	IEnumerator DecreaseSpawnIntervalCoroutine()
	{
		while (true) {
			yield return new WaitForSeconds (decreaseTime);
			minSpawnInterval = Mathf.Max (minSpawnIntervalCap, minSpawnInterval - minSpawnIntervalDecreaseRate);
			maxSpawnInterval = Mathf.Max (maxSpawnIntervalCap, maxSpawnInterval - maxSpawnIntervalDecreaseRate);
		
		}
	}
}
