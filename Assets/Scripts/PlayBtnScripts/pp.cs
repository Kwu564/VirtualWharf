﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.Animations;

// Hover on button, and it expands.
// Collision detection is only on the circle instead of the whole button

public class pp : MonoBehaviour{
	public GameObject PlayButtonMM;
	private Animation anim;
	public bool paused;

	void Start(){
		paused = true;
		anim = PlayButtonMM.GetComponent<Animation> ();
	}
	void Update(){
		// If paused, play
		// else, reset animation by going to the first frame
		if (!paused) {
			anim["playTest"].speed = 2.5f;
			anim.Play ();
		} else if(paused) {
			anim ["playTest"].time = 0f;
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
	public void OnMouseOver(){
		paused = false;
//		anim.Play();
		if (Input.GetMouseButtonDown (0)) {
			SceneManager.LoadScene ("sceneOne");
		}else if(Input.GetButtonDown("Submit")){ //checks if x button is down
			SceneManager.LoadScene ("sceneOne");
		}

	}

	// Checking if mouse is not on button anymore
	void OnMouseExit(){
		paused = true;
	
    }
	// This number is the time of the last frame
	void stopAnim(){
		anim ["playTest"].time = 0.925f;
	}
}