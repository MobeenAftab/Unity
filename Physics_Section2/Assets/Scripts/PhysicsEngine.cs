using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PhysicsEngine : MonoBehaviour {

	public Vector3 velocityVector;	//average velocity for fixedUpdate()
	public Vector3 netForceVector;
	public List<Vector3> forceVectorList = new List<Vector3> ();	//add multiple forces to object

	// Use this for initialization
	void Start () {
	
	}
	//called at a constant 20ms
	void FixedUpdate() {
		AddForces ();
		if (netForceVector == Vector3.zero) {	//if no net force
			//adding to the current position the ammount of displacment velocityVector
			transform.position += velocityVector * Time.deltaTime;
		} else { //if net force unbalanced
			Debug.LogError("Unbalanced for detected, help !");
		}
	}

	void AddForces () {
		netForceVector = Vector3.zero;
		//for each force vector of type V3 in the FVL list 
		foreach (Vector3 forceVector in forceVectorList) {
			netForceVector = netForceVector + forceVector;
		}	//add all the forces and outputs results
	}
}
