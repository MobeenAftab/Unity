using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    // Public member vairables
    public Rigidbody bullet;
    public float power = 1500f;
    public float moveSpeed = 2f;

	// Update is called once per frame
	void Update () {
		// Get the axis from the Input manager 
		float horizontal = Input.GetAxis ("Horizontal") * Time.deltaTime * moveSpeed;
		float vertical = Input.GetAxis ("Vertical") * Time.deltaTime * moveSpeed;

		// Move camera on axis using W,A,S,D
		transform.Translate (horizontal, vertical, 0);

		// If left mouse click pressed 
		if (Input.GetButtonUp ("Fire1")) {
			// Instanciate Projectile on click
			Rigidbody instance = Instantiate(bullet, transform.position, transform.rotation) as Rigidbody;
			// Add forward (Z-axis) force on instanciated object
			Vector3 forwardforce = transform.TransformDirection (Vector3.forward);
			// Move objetc in Z-axis in world space by this force amount
			instance.AddForce(forwardforce * power);
		}
	}
}
