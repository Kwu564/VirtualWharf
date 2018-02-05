using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Animations;

// Hover on button, and it expands.
// Collision detection is only on the circle instead of the whole button

public class creditsAnim : MonoBehaviour{
	public GameObject CreditsButton;
	private Animation anim;
	public bool paused;

	void Start(){
		paused = true;
		anim = CreditsButton.GetComponent<Animation> ();
	}
	void Update(){
		// If paused, play
		// else, reset animation by going to the first frame
		if (!paused) {
			anim["creditsButtonAnm"].speed = 2.5f;
			anim.Play ();
		} else if(paused) {
			anim ["creditsButtonAnm"].time = 0f;
		}
	}
	// This is called when the animation reaches the last frame
	// It freezes on the last frame to show the entire button
	void finishAnim(){
		stopAnim ();
	}
	// Checking if mouse is entering button
	void OnMouseEnter(){
		paused = false;
		anim.Play();
	}
	// Checking if mouse is on button
	void OnMouseOver(){
		paused = false;
		anim.Play();
		if(Input.GetMouseButtonDown(0) ){
			SceneManager.LoadScene ("CreditsPage");
		}
	}

	// Checking if mouse is not on button anymore
	void OnMouseExit(){
		paused = true;

	}
	// This number is the time of the last frame
	void stopAnim(){
		anim ["creditsButtonAnm"].time = 0.6166667f;
	}
}