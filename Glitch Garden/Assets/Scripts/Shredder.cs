using UnityEngine;
using System.Collections;

public class Shredder : MonoBehaviour {

	//Destroy any game object that collides with shredder
	void OnTriggerEnter2D (Collider2D collider) {
		Destroy (collider.gameObject);
	}
	//by passing a collider parameter the shredder will destroy collision only objects 
	//and not itself
}
