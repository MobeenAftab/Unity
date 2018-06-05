using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	//creating an instance called levelmanager of the class LevelManager to use its variables
	//dont forget to connect the object 'LevelManager' into the LoseCollider script inspector tab
	private LevelManager levelmanager;

	//variable triger is called upon method ontriggerenter2D of collider2D type
	void OnTriggerEnter2D (Collider2D trigger) {
		levelmanager = GameObject.FindObjectOfType<LevelManager>();
		levelmanager.LoadLevel("Lose Screen");
	}

	//variable collision is called upon method OnCollisionEnter2D of Collision2D type
	//use the matrix table chart for future reference into designing game object physics
	//in this instance we are using triger not collision
	void OnCollisionEnter2D (Collision2D collision) {
		print("collision");
	} 
}
