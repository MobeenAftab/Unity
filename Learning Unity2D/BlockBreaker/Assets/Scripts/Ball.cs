using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private paddle Paddle;
	private Vector3 paddleToBallVector;
	private bool hasStarted = false;	//check if game is running

	// Use this for initialization
	void Start () {
		//finding game object for prefrab and of type <paddle>
		Paddle = GameObject.FindObjectOfType<paddle>();
		//This is useful because it means i can create many prefab instances of this object in various scenes
		//and never worry about linking that new instance of the object to the correct inpector element in the IDE
		//use this for classes that you plan on re-using often
		 
		//subtracts all the three vector cordinates between the ball= this and the Paddle class instance
		paddleToBallVector = this.transform.position - Paddle.transform.position;
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		//if games has NOT started run code below
		if (!hasStarted) {
			//sets the position of the ball to the paddle relative to the ball's starting position
			this.transform.position = Paddle.transform.position + paddleToBallVector;
			/* note that the paddle and ball are two different scripts that update in the unity execution model 
			* at random unless previously defined. to keep the ball exactly on the paddle at the defined position
			* simply go to edit>project setup>script execution order and set the order of script execution order.
			* this will be especially helpful for the instances you have a script relying on constantly updating 
			* values to perform calculations on and require accuracy
			*/

			//if left mouse button is clicked
			if (Input.GetMouseButtonDown (0)) {
				print ("mouse clicked, launching ball");
				hasStarted = true;	//sets hasStarted to true thus forcing the first block of if statment to never run
				//this stops the ball from returning to the relative paddle position and allows the physics effect to take place

				//rgidbody2d.velocity is a vector2 that holds X,Y components and effects the physics of the ball using a velocity force
				//this.rigidbody2D.velocity = new Vector2 (2f, 10f); this line is obsolete new unity line below::
				this.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
			}
		}
	
	}

	void OnCollisionExit2D (Collision2D collision) {
		//tweaking the velocity of the ball
		Vector2 tweak = new Vector2 (Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, 0.2f));

		if(hasStarted) {
			GetComponent<AudioSource> ().Play ();	//new unity 5 audio source play method
			this.gameObject.GetComponent<Rigidbody2D> ().velocity += tweak;
		}
	}
}
