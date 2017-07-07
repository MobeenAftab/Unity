using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour {


	public void Begin() {
		Debug.Log ("Begin");
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void PlayAgain() {
		Debug.Log ("Restart");
		SceneManager.LoadScene ("BlockRun_1");
	}

	public void Quit() {

		Debug.Log ("Quit");
		Application.Quit ();
	}
}
