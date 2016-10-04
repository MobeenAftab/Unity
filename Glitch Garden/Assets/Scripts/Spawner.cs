using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	//an array of all possible attacker spawns
	public GameObject[] attackerPrefabArray;


	// Update is called once per frame
	void Update () {	//spawing attackers from array
		foreach (GameObject thisAttacker in attackerPrefabArray) {
			if (isTimeToSpawn (thisAttacker)) {	//if its time to spawn = true
				Spawn (thisAttacker);	//spawn attacker object 
			}
		}
	}

	//spawn attacker method
	void Spawn (GameObject myGameObject) {
		GameObject myAttacker = Instantiate (myGameObject) as GameObject;
		myAttacker.transform.parent = transform;	//set transform/position to parent
		myAttacker.transform.position = transform.position;	//spawn at the parent transform
	}

	//check if its time for object spawn
	bool isTimeToSpawn (GameObject attackerGameObject) {
		Attacker attacker = attackerGameObject.GetComponent<Attacker> ();

		//calculating spawn time
		float meanSpawnDelay = attacker.seenEverySeconds;
		float spawnsPerSecond = 1 / meanSpawnDelay;

		if (Time.deltaTime > meanSpawnDelay) {
			Debug.Log ("Spawn rate capped by frame rate");
		}

		//if value is > 1 spawn, if < 1 dont
		float threshold = spawnsPerSecond * Time.deltaTime / 5;

		if (Random.value < threshold) {
			return true;
		} else {
			return false;
		}
		return true;
	}
}
