/* 
 * Script to move objects in game scene dynamically
 * Resources Used:
 * https://en.wikipedia.org/wiki/Sine
 * https://en.wikipedia.org/wiki/Turn_(geometry)#Tau_proposal
 * https://docs.unity3d.com/ScriptReference/Mathf.Sin.html
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Attribute to stop duplicate script on component
[DisallowMultipleComponent]
public class Oscillator : MonoBehaviour {

    [SerializeField] Vector3 movementVector;
    [SerializeField] float period = 2f;

    float movementFactor;

    Vector3 startingPos;

	// Use this for initialization
	void Start () {
        startingPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        objectMovement();   
	}

    public void objectMovement() {
        // Protect against period == 0 (NaN)
        if (period <= Mathf.Epsilon) { return; }

        // Grows continually from 0
        float cycles = Time.time / period;

        // About 6.28
        const float tau = Mathf.PI * 2;

        // Range from -1 - +1
        float rawSineWave = Mathf.Sin(cycles * tau);

        // Bind movementFactor to 0 - 1 range
        movementFactor = (rawSineWave / 2f) + 0.5f;
        Vector3 offset = movementFactor * movementVector;

        transform.position = startingPos + offset;
    }
}
