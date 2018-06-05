using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Defender : MonoBehaviour {

	public int starCost = 10;

	private StarDisplay starDisplay;

	void Start () {
		
		starDisplay = GameObject.FindObjectOfType<StarDisplay> ();
	}

	public void AddStart (int amount) {
		
		starDisplay.AddStart (amount);
	}

	/*void OnTriggerEnter2D () {
		Debug.Log (name + " trigger enter");
	}*/
}
