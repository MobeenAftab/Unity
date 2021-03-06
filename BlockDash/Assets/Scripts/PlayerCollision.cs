﻿using UnityEngine;

public class PlayerCollision : MonoBehaviour {

	public PlayerMovement movement;
	//public GameManager GM;

	//Detect and print name of any collision
	void OnCollisionEnter(Collision collisionInfo) {
		//Debug.Log (collisionInfo.collider.name);

		if (collisionInfo.collider.tag == "Obstacle") {
			Debug.Log (collisionInfo.collider.name);
			movement.enabled = false;
			FindObjectOfType<GameManager> ().GameOver();
		}
	}
}
