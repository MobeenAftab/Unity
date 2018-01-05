// Script to move objects in game scene dynamically

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Attribute to stop duplicate script on component
[DisallowMultipleComponent]
public class Oscillator : MonoBehaviour {

    [SerializeField] Vector3 movementVector;
    [SerializeField] [Range(0,1)] float movementFactor;

    Vector3 startingPos;

	// Use this for initialization
	void Start () {
        startingPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 offset = movementFactor * movementVector;
        transform.position = startingPos + offset;
	}
}
