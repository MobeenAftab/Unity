using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

	public Camera myCamera;

	private GameObject defenderParent;
	private StarDisplay starDisplay;

	void Start() {

		starDisplay = GameObject.FindObjectOfType<StarDisplay> ();

		//sub all defender spws under one defender element in the inspector - like the projectile object
		defenderParent = GameObject.Find ("Defenders");
		if(!defenderParent) {
			defenderParent = new GameObject("Defenders");
		}
	}

	void OnMouseDown() {
		//print mouse position on click in console
		//print (Input.mousePosition);
		//print ( SnapToGrid(CalculateWorldPointOfMouseClick()) );

		//spawn defender at location of grid after button select
		Vector2 rawPos = CalculateWorldPointOfMouseClick();	//get raw position
		Vector2 roundedPos = SnapToGrid (rawPos);	//use method to round
		GameObject defender = Button.selectedDefender;	//get selected defender

		//Get cost of each defender
		int defenderCost = defender.GetComponent<Defender>().starCost;
		//Only spawn defender if enough starts
		if (starDisplay.UseStar (defenderCost) == StarDisplay.Status.SUCCESS) {
			SpawnDefender (roundedPos, defender);
		} else {
			Debug.Log ("Not enough Starts to spawn!");
		}
	}

	void SpawnDefender (Vector2 roundedPos, GameObject defender) {
		
		Quaternion zeroRotation = Quaternion.identity;
		//unity required var in instantiate
		GameObject newDef = Instantiate (defender, roundedPos, zeroRotation) as GameObject;
		//instanciates new defenders and spawns them at rounded position under defender element
		newDef.transform.parent = defenderParent.transform;
		//assigns defenders a parent def on spawn
	}

	//get unrounded world space pos and round to grid center
	Vector2 SnapToGrid (Vector2 rawWorldPos) {
		float newX = Mathf.RoundToInt (rawWorldPos.x);
		float newY = Mathf.RoundToInt (rawWorldPos.y);
		return new Vector2 (newX, newY);
	}

	Vector2 CalculateWorldPointOfMouseClick() {
		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		float distanceFromCamera = 10f;	//no Z depth in the camera perspective

		//weirdTriplet because Z position is invalid in our camera scope this distfromCam is set to 10f
		Vector2 weirdTriplet = new Vector3 (mouseX, mouseY, distanceFromCamera);
		Vector2 worldPos = myCamera.ScreenToWorldPoint (weirdTriplet);

		return worldPos;
	}


}
