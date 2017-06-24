using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	//Referencing rigidbody component
	public Rigidbody rb;

	public float xforce = 100f;
	public float yforce = 1000f;

	// Update on Fixed FPS
	void FixedUpdate () {
		
		rb.AddForce (0, 0, yforce * Time.deltaTime);

		//ForceMode.VelocityChange - ignores mass and momentum in objects, add new force immediately 
		//Move right
		if (Input.GetKey(KeyCode.D)) {
			rb.AddForce (xforce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
		}
		//Move left
		if (Input.GetKey(KeyCode.A)) {
			rb.AddForce (-xforce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
		}
	}

}
