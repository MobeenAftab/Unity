using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour {

    // TODO:: Add sound for rocket

    [SerializeField] float rcsThrust = 100f;
    [SerializeField] float mainThrust = 100f;
    float transitionDelay = 1f;

	Rigidbody rigidBody;
    AudioSource audioSource;

    enum State { Alive, Dying, Transcending }
    State state = State.Alive;

	// Use this for initialization
	void Start () {
		// Get rigidBody of rocket ship
		rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (state == State.Alive) {
            thrust();
            rotate();   
        }
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

        // Exit method gaurd condition
        if (state != State.Alive) {
            return;
        }

        switch (collision.gameObject.tag)
        {
            case "Friendly":
                print("OK");
                break;
            case "Finish":
                state = State.Transcending;
                Invoke("loadNextLevel", transitionDelay);
                break;
            default:
                print("You Died");
                state = State.Dying;
                Invoke("loadFirstLevel", transitionDelay);
                break;
        }
	}

    private void loadNextLevel() {
        SceneManager.LoadScene(1);
    }

    private void loadFirstLevel() {
        SceneManager.LoadScene(0);
    }
}
