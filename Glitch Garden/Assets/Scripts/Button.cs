using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	//each button now has prefab instance
	public GameObject defenderPrefab;
	public static GameObject selectedDefender;

	private Button[] buttonArray;

	// Use this for initialization
	void Start () {
		buttonArray = GameObject.FindObjectsOfType<Button> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//intercepting clicks on sprite buttons
	void OnMouseDown() {
		//print (name + " pressed");

		//set all button sprite to black
		foreach(Button thisButton in buttonArray){
			thisButton.GetComponent<SpriteRenderer> ().color = Color.black;
		}
		//set sprite to white on click
		GetComponent<SpriteRenderer>().color = Color.white;
		selectedDefender = defenderPrefab;
		print (selectedDefender);
	}
}
