using UnityEngine;
using System.Collections;

public class FallingWeapon : MonoBehaviour 
{
	//weapon currently equipped
	static GameObject currEquippedWeapon = null;

	//the weapon that the player would wear after collecting this FallingWeapon
	public GameObject weaponPrefab;

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player") {
			if (currEquippedWeapon != null)
				Destroy (currEquippedWeapon); //destroy the previous weapon

			//inform the player that he/she gets a new weapon
			GameObject.FindGameObjectWithTag ("Player").GetComponent<Character> ().GetWeapon ();

			//intantiates the weapon
			GameObject weapon = (Instantiate (weaponPrefab, new Vector3 (col.gameObject.transform.position.x, col.gameObject.transform.position.y, -0.1f), Quaternion.identity) as GameObject);

			//set Player as the parent of the weapon (so that weapon would move according to Player)
			weapon.transform.parent = col.gameObject.transform;

			//record the new weapon as the currEquippedWeapon
			currEquippedWeapon = weapon;

			//destroy the falling weapon
			Destroy (gameObject);

		} else if (col.gameObject.tag == "Shou Lin") {
			Destroy (col.gameObject); //destroy the Shou Lin scarf

			GameObject player = GameObject.FindGameObjectWithTag ("Player");
			player.GetComponent<Character> ().GetWeapon (); //inform player
			player.GetComponent<Collider2D> ().enabled = true; //reenable the Collider 2D component of player (for hurt/weapon collection)

			//instantiate weapon
			GameObject weapon = (Instantiate (weaponPrefab, new Vector3 (player.transform.position.x, player.transform.position.y, -0.1f), Quaternion.identity) as GameObject);

			//set Player as the parent of the weapon (so that weapon would move according to Player)
			weapon.transform.parent = player.transform;

			//record the new weapon as the currEquippedWeapon
			currEquippedWeapon = weapon;

			//destroy the falling weapon
			Destroy (gameObject);
		}
	}
}
