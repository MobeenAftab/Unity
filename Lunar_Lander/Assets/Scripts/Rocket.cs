using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    [SerializeField] float rcsThrust = 100f;
    [SerializeField] float mainThrust = 100f;

	Rigidbody rigidBody;
    AudioSource audioSource;

	// Use this for initialization
	void Start () {
		// Get rigidBody of rocket ship
		rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        thrust();
        rotate();
	}

    private void rotate() {
        // Take manual control of rocket rotation
        rigidBody.freezeRotation = true;

        // Manually set rotation speed of rocket
        float rotationThisFrame = rcsThrust * Time.deltaTime;

		if (Input.GetKey(KeyCode.A)) {
            transform.Rotate(Vector3.forward * rotationThisFrame);
		} else if (Input.GetKey(KeyCode.D)) {
            transform.Rotate(-Vector3.forward * rotationThisFrame);
		}

        // Return rotation control
        rigidBody.freezeRotation = false;
	}

    private void thrust() {
        if (Input.GetKey(KeyCode.Space)) {
            rigidBody.AddRelativeForce(Vector3.up * mainThrust);
        }
    }

    private void playAudio() {
        if (!audioSource.isPlaying) {
            audioSource.Play();
        } else {
            audioSource.Stop();
        }
    }

    void OnCollisionEnter(Collision collision) {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                print("OK");
                break;
            case "Fuel":
                print("Fuel");
                break;
            default:
                print("Dead");
                break;
        }
	}
}
