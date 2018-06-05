using UnityEngine;
using System.Collections;

public class Shooters : MonoBehaviour {

	//open gameObject slots under script inspector to identify objects to be
	//manipulated in script
	public GameObject projectile, gun;

	private GameObject projectileParent;
	private Animator animator;
	private Spawner myLaneSpawner;

	void Start() {
		//Find animator object
		animator = GameObject.FindObjectOfType<Animator> ();

		//assign projectile parent to each projectile
		projectileParent = GameObject.Find ("Projectiles");
		//if no projectile parent create one
		if(!projectileParent) {
			//instanciates all projectiles under one section in inspector
			projectileParent = new GameObject("Projectiles");
			//projectileParent.name = "Projectiles"; 
			//names the new game object projectiles so all projectiles sub under its instance
		}
		SetMyLaneSpawner ();
	}

	void Update() {

		//Set attack mode on defender based on oponent location
		if (IsAttackerheadInLane ()) {
			animator.SetBool ("isAttacking", true);
		} else {
			animator.SetBool ("isAttacking", false);
		}
	}

	//check if enemy is ahead in lane
	private bool IsAttackerheadInLane() {

		//Exit if not attackers in lane
		if (myLaneSpawner.transform.childCount <= 0) {
			return false;
		}

		//Loop through child elements transform pos in lane
		foreach (Transform attackersChild in myLaneSpawner.transform) {
			if (attackersChild.transform.position.x > transform.position.x) {
				return true;
			}
		}
		//If attackers behind defenders in lane X.pos isAttacking = false
		return false;
	}

	//Look through all spawners and setMyLaneSpawner if found
	void SetMyLaneSpawner () {

		Spawner[] spawnerArray = GameObject.FindObjectsOfType<Spawner> ();

		foreach (Spawner spawner in spawnerArray) {
			if (spawner.transform.position.y == transform.position.y) {
				myLaneSpawner = spawner;
				return;
			}
		}

		Debug.Log (name + " Cant find spawner in lane");
	}

	private void fire() {
		//spawn projectile at parent projectile location
		GameObject newProjectile = Instantiate (projectile) as GameObject;
		newProjectile.transform.parent = projectileParent.transform;
		newProjectile.transform.position = gun.transform.position;
	}



}
