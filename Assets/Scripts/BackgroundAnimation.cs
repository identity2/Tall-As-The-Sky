using UnityEngine;
using System.Collections;

public class BackgroundAnimation : MonoBehaviour 
{
	//duration between a day/night switch
	public float dayNightDuration;

	//the min and max position that a cloud(day) or star(night) would spawn between
	public Transform cloudStarMinSpawnTransform;
	public Transform cloudStarMaxSpawnTransform;

	//the sun(day) or moon(night) would move from StartTransform to EndTransform during dayNightDuration
	public Transform sunMoonStartTransform;
	public Transform sunMoonEndTransform;

	//interval between two waves of cloud/star spawn
	public float cloudStarSpawnMinInterval;
	public float cloudStarSpawnMaxInterval;

	//min/max amount of cloud/star spawn per interval
	public int cloudStarSpawnMinAmount;
	public int cloudStarSpawnMaxAmount;

	public Color dayColor; //background color for day
	public GameObject sun; //sun gameobject
	public GameObject[] cloudPrefabs; //prefabs of different clouds

	public Color nightColor; //background color for night
	public GameObject moon; //moon gameobject
	public GameObject[] starPrefabs; //prefabs of different stars

	void Start()
	{
		StartCoroutine (MainCoroutine ());
	}

	IEnumerator MainCoroutine()
	{
		//keep a reference of the current SpawnCloudStarCoroutine
		Coroutine spawnCoroutine = null;

		while (true) {
			if (spawnCoroutine != null)
				StopCoroutine (spawnCoroutine); //stop the current SpawnCloudStarCoroutine in order to switch from day to night

			spawnCoroutine = StartCoroutine (SpawnCloudStarCoroutine (false)); //coroutine for spawning stars
			StartCoroutine (ColorLerpCoroutine (nightColor, dayColor)); //coroutine for gradual background color shift
			StartCoroutine (SunMoonMovingCoroutine (moon)); //coroutine for the movement of moon

			//wait until day
			yield return new WaitForSeconds (dayNightDuration);

			StopCoroutine (spawnCoroutine); //stop spawning stars
			spawnCoroutine = StartCoroutine (SpawnCloudStarCoroutine (true)); //coroutine for spawning clouds
			StartCoroutine (ColorLerpCoroutine (dayColor, nightColor)); //coroutine for gradual background color shift
			StartCoroutine (SunMoonMovingCoroutine (sun)); //coroutine for the movement of sun

			//wait until night
			yield return new WaitForSeconds (dayNightDuration);
		}
	}

	//gradually change from "fromColor" to "toColor" over "dayNightDuration" seconds 
	IEnumerator ColorLerpCoroutine(Color fromColor, Color toColor)
	{
		float i = 0f;
		while (i <= 1f) {
			i += Time.deltaTime / dayNightDuration;
			GetComponent<SpriteRenderer> ().color = Color.Lerp (fromColor, toColor, i);
			yield return null;
		}
	}

	//gradually move "obj" from "sunMoonStartTransform" to "sunMoonEndTransform" over "dayNightDuration" seconds
	IEnumerator SunMoonMovingCoroutine(GameObject obj)
	{
		float i = 0f;
		while (i <= 1f) {
			i += Time.deltaTime / dayNightDuration;
			obj.transform.position = Vector3.Lerp (sunMoonStartTransform.transform.position, sunMoonEndTransform.transform.position, i);
			yield return null;
		}
	}

	IEnumerator SpawnCloudStarCoroutine(bool cloud)
	{
		while (true) {
			//how many to spawn
			int spawnAmount = Random.Range (cloudStarSpawnMinAmount, cloudStarSpawnMaxAmount + 1);

			while (spawnAmount > 0) {

				//intiantiate in random position between the range
				Instantiate(
					cloud ? cloudPrefabs[Random.Range(0, cloudPrefabs.Length)] : starPrefabs[Random.Range(0, starPrefabs.Length)],
					new Vector3(
						Random.Range(cloudStarMinSpawnTransform.transform.position.x, cloudStarMaxSpawnTransform.transform.position.x),
						cloudStarMinSpawnTransform.transform.position.y,
						cloudStarMinSpawnTransform.transform.position.z
					),
					Quaternion.identity
				);
				spawnAmount--;
			}

			//wait for next spawn
			yield return new WaitForSeconds (Random.Range (cloudStarSpawnMinInterval, cloudStarSpawnMaxInterval));
		}
	}
}
