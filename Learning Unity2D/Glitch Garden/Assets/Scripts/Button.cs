using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Button : MonoBehaviour {

	//each button now has prefab instance
	public GameObject defenderPrefab;
	public static GameObject selectedDefender;

	private Button[] buttonArray;
	private Text cost;
	 

	// Use this for initialization
	void Start () {
		buttonArray = GameObject.FindObjectsOfType<Button> ();

		cost = GetComponentInChildren<Text> ();
		if (!cost) {
			Debug.LogWarning (name + "Does not have a cost text");
		}

		cost.text = defenderPrefab.GetComponent<Defender> ().starCost.ToString ();

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