using UnityEngine;
using System.Collections;

public class paddle : MonoBehaviour {

	public bool autoPlay = false;

	private Ball ball;

	// Use this for initialization
	void Start () {
	
		ball = GameObject.FindObjectOfType<Ball> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!autoPlay) {
			moveWithMouse ();
		} else {
			AutoPlay ();
		}
	}

	//auto play lets the AI play test the game by constantly updating the 
	//Y pos of the paddle under the Y pos of the ball
	void AutoPlay() {
		
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);
		Vector3 ballPos = ball.transform.position;
		paddlePos.x = Mathf.Clamp (ballPos.x, 1.18f, 14.8f);
		this.transform.position = paddlePos;

	}

	void moveWithMouse() {
		float min = 1.18f;
		float max = 14.8f;

		//Vector 3 is a way o store 3 float values that represent the X,Y and Z elements of a graph
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);
		//this = keep Y coridinate equal to the current position
		//this variable calculate the x position of the mouse in game world blocks - relative to the screen width
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16 ;

		//sets the X position of the paddle to be equal to the x position of the mouse in game blocks
		//mathsF.clamp keeps the paddle within the set min/max range of the game screen as defined here
		//mthf.clamp(float value, float min, float max); its of type float and requires three parameters
		paddlePos.x = Mathf.Clamp(mousePosInBlocks, min, max);

		//this == the instance of the current script
		this.transform.position = paddlePos;
	}
}
