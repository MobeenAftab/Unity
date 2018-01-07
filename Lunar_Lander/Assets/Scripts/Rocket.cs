using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour {

    // TODO:: Add sound for rocket

    [SerializeField] float rcsThrust = 100f;
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float transitionDelay = 2f;

    [SerializeField] AudioClip mainEngine_SFX;
    [SerializeField] AudioClip death_SFX;
    [SerializeField] AudioClip levelComplete_SFX;

    [SerializeField] ParticleSystem mainEngine_Particles;
    [SerializeField] ParticleSystem death_Particles;
    [SerializeField] ParticleSystem levelComplete_Particles;

    float SFXVolume = 1f;
    bool collisionsActive = true;

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
        // Keys only active during debug mode
        if (Debug.isDebugBuild) {
            debugKeys();
        }
	}

    // Debug keys for run time
    private void debugKeys() {
        if (Input.GetKeyDown(KeyCode.L)) {
            levelComplete();
        } else if (Input.GetKeyDown(KeyCode.C)) {
            collisionsActive = !collisionsActive;
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
            rigidBody.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
            playAudio(mainEngine_SFX, SFXVolume);
            mainEngine_Particles.Play();
        } else {
            audioSource.Stop();
            mainEngine_Particles.Stop();
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
        levelComplete_Particles.Play();
        playAudio(levelComplete_SFX, SFXVolume);
        Invoke("loadNextLevel", transitionDelay);
    }

    private void playerDeath() {
        print("You Died");
        audioSource.Stop();
        state = State.Dying;
        death_Particles.Play();
        playAudio(death_SFX, SFXVolume);
        Invoke("loadFirstLevel", transitionDelay);
    }

    void OnCollisionEnter(Collision collision) {

        // Exit method gaurd condition
        if (state != State.Alive || !collisionsActive) {
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
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = currentScene + 1;

        if (SceneManager.sceneCountInBuildSettings != nextScene) {
            SceneManager.LoadScene(nextScene);
        } else {
            loadFirstLevel();
        }
    }

    private void loadFirstLevel() {
        SceneManager.LoadScene(0);
    }
}
