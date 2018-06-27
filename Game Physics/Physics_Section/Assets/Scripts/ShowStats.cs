using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Update while playing and in edit mode
[ExecuteInEditMode]
// Print out how unity calculates Inertia Tensors
public class ShowStats : MonoBehaviour {

	private Rigidbody rigidBody;
	private GameObject gameobject;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (gameObject.name + " " + rigidBody.inertiaTensor);
	}
}
