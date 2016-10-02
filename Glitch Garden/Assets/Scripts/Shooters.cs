using UnityEngine;
using System.Collections;

public class Shooters : MonoBehaviour {

	//open gameObject slots under script inspector to identify objects to be
	//manipulated in script
	public GameObject projectile, gun;

	private GameObject projectileParent;

	void Start() {
		//assign projectile parent to each projectile
		projectileParent = GameObject.Find ("Projectiles");
		//if no projectile parent create one
		if(!projectileParent) {
			//instanciates all projectiles under one section in inspector
			projectileParent = new GameObject("Projectiles");
			//projectileParent.name = "Projectiles"; 
			//names the new game object projectiles so all projectiles sub under its instance
		}
	}

	private void fire() {
		//spawn projectile at parent projectile location
		GameObject newProjectile = Instantiate (projectile) as GameObject;
		newProjectile.transform.parent = projectileParent.transform;
		newProjectile.transform.position = gun.transform.position;


	}



}
