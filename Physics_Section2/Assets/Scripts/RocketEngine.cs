using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PhysicsEngine))]
public class RocketEngine : MonoBehaviour {

	public float fuelMass;		// [Kg]
	public float maxThrust;		// kN [kg m s^-2]

	[Range(0, 1f)]
	public float thrustPercent;	// [none]
	public Vector3 thrustUnitVector;	//[none}

	private PhysicsEngine physicsEngine;
	private float currentThrust;	// N

	// Use this for initialization
	void Start () {
		physicsEngine = GetComponent<PhysicsEngine>();
		physicsEngine.mass += fuelMass;
	}

	void FixedUpdate () {
		if (fuelMass > fuelUpdate ()) {
			fuelMass -= fuelUpdate ();
			physicsEngine.mass -= fuelUpdate ();
			exertForce ();
		} else {
			Debug.LogWarning ("Fuel depleted");
		}
	}

	float fuelUpdate() {
		float exhaustMassFlow;
		float effectiveExhaustVelocity = 4463f;

		exhaustMassFlow = currentThrust / effectiveExhaustVelocity;

		return exhaustMassFlow * Time.deltaTime;
	}

	void exertForce() {
		currentThrust = thrustPercent * maxThrust * 1000f;
		Vector3 thrustVector = thrustUnitVector.normalized * currentThrust;
		physicsEngine.AddForce (thrustVector);
	}

}
