using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public GameObject levelComplete;

	bool isGameOver = false;
	float delay = 2f;

	public void GameWon() {
		Debug.Log ("Game Won");
	}

	public void GameOver() {

		if (isGameOver == false) {
			isGameOver = true;
			Debug.Log ("Game Over");
			Invoke("Restart", delay);
		}
	}

	void Restart() {
		
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}

	public void LevelComplete() {

		levelComplete.SetActive (true);
	}
}
