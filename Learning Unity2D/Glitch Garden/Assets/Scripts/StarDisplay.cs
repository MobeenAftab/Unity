using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Text))]

public class StarDisplay : MonoBehaviour {

	public enum Status {SUCCESS, FAIL};

	private StarDisplay starDisplay;
	private Text starD;
	private int stars = 100;

	// Use this for initialization
	void Start () {

		starDisplay = GameObject.FindObjectOfType<StarDisplay> ();
		//Use getComponent when refrencing inner components in object
		starD = GetComponent<Text> ();
		UpdateDisplay ();		
	}

	public void AddStart (int amount) {

		stars += amount;
		UpdateDisplay ();
	}

	public Status UseStar (int amount) {

		if (stars >= amount) {
			stars -= amount;
			UpdateDisplay ();
			return Status.SUCCESS;
		} 

		return Status.FAIL;
	}

	private void UpdateDisplay() {
		starD.text = stars.ToString ();
	}
}
