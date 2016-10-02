using UnityEngine;
using System.Collections;

public class Defender : MonoBehaviour {

	//This script is being used as a tag for the defenders class

	void OnTriggerEnter2D () {
		Debug.Log (name + " trigger enter");
	}
}
