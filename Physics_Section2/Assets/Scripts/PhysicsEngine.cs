using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PhysicsEngine : MonoBehaviour {

	public float mass;
	public Vector3 velocityVector;	//average velocity for fixedUpdate()
	public Vector3 netForceVector;

	private List<Vector3> forceVectorList = new List<Vector3> ();	//add multiple forces to object

	// Use this for initialization
	void Start () {
		forceTrails ();
	}
	//called at a constant 20ms
	void FixedUpdate() {
		renderTrails ();
		updatePosition ();
	}

	public void AddForce(Vector3 forceVector) {
		forceVectorList.Add (forceVector);
	}

	//Newtons second law of motion
	void updatePosition () {
		//sum the forces and clear list
		netForceVector = Vector3.zero;
		foreach (Vector3 forceVector in forceVectorList) {
			netForceVector = netForceVector + forceVector;
		}

		forceVectorList = new List<Vector3> ();	//clear the list

		//calculate position change due to net force
		Vector3 accelerationVector = netForceVector / mass;	// F = ma
		//change of velocity depends on duration of force
		velocityVector += accelerationVector * Time.deltaTime;

		//update position
		transform.position += velocityVector * Time.deltaTime;
	}


	//code for drawing trails
	public bool showTrails = true;

	private LineRenderer lineRenderer;
	private int numberOfForces;

	// Use this for initialization
	void forceTrails () {
		lineRenderer = gameObject.AddComponent<LineRenderer>();
		lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
		lineRenderer.SetColors(Color.yellow, Color.yellow);
		lineRenderer.SetWidth(0.2F, 0.2F);
		lineRenderer.useWorldSpace = false;
	}

	// Update is called once per frame
	void renderTrails () {
		if (showTrails) {
			lineRenderer.enabled = true;
			numberOfForces = forceVectorList.Count;
			lineRenderer.SetVertexCount(numberOfForces * 2);
			int i = 0;
			foreach (Vector3 forceVector in forceVectorList) {
				lineRenderer.SetPosition(i, Vector3.zero);
				lineRenderer.SetPosition(i+1, -forceVector);
				i = i + 2;
			}
		} else {
			lineRenderer.enabled = false;
		}
	}

}

