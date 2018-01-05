﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour {

    // TODO:: Add sound for rocket

    [SerializeField] float rcsThrust = 100f;
    [SerializeField] float mainThrust = 100f;
    [SerializeField] AudioClip mainEngine_SFX;
    [SerializeField] AudioClip death_SFX;
    [SerializeField] AudioClip levelComplete_SFX;

    float transitionDelay = 1f;
    float SFXVolume = 1f;

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
            playAudio(mainEngine_SFX, SFXVolume);
        }
    }

    private void playAudio(AudioClip sound, float volume) {
        if (!audioSource.isPlaying) {
            audioSource.PlayOneShot(sound, volume);
        } else {
            audioSource.Stop();
        }
    }

    private void levelComplete() {
        state = State.Transcending;
        playAudio(levelComplete_SFX, SFXVolume);
        Invoke("loadNextLevel", transitionDelay);
    }

    private void playerDeath() {
        print("You Died");
        audioSource.Stop();
        state = State.Dying;
        playAudio(death_SFX, SFXVolume);
        Invoke("loadFirstLevel", transitionDelay);
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
                levelComplete();
                break;
            default:
                playerDeath();
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
