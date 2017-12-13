using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

	Rigidbody rigidBody;

	// Use this for initialization
	void Start () {
		// Get rigidBody of rocket ship
		rigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		processInput();
	}

	private void processInput() {
		if (Input.GetKey(KeyCode.Space)) {
			rigidBody.AddRelativeForce(Vector3.up);
		}

		if (Input.GetKey(KeyCode.A)) {
			print ("Rotate Left");
		} else if (Input.GetKey(KeyCode.D)) {
			print ("Rotate Right");
		}

	}

}
