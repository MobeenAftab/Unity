//Author : Mobeen Aftab
//Date : 06/11/2015

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour {

	//using the UI element panel we are creating a 'fade in' effect over the UI of our game.
	//we do this by adjusting the alpha channel of the panel

	public float fadeInTime;

	private Image fadePanel;
	private Color currentColor = Color.black;

	// Use this for initialization
	void Start () {
		fadePanel = GetComponent<Image> ();	//getting the image tab from the inspecter of panel

	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeSinceLevelLoad < fadeInTime) {
			//Fade in algorithm / method
			float alphaChange = Time.deltaTime / fadeInTime;
			currentColor.a -= alphaChange;
			fadePanel.color = currentColor;
		} else {	//this disables the gameObject UI.panel element after the fade effect has finished
			gameObject.SetActive (false);
		}
	}
}
