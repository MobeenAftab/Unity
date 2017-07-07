using UnityEngine;

public class EndPoint : MonoBehaviour {

	public GameManager GM;

	void OnTriggerEnter() {

		GM.LevelComplete ();
	}
}
