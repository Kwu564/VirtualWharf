﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine;

public class InstructionsScript : MonoBehaviour {
	public Button ControlsButton;
	public Button VideoButton;
	public bool PlayerOneIsReady;
	public RawImage TutorialRawImage;
	public VideoClip TutorialVideo;
	private VideoPlayer VidPlayer;
	public bool PlayerTwoIsReady;
	public bool BothPlayersAreReady;
	public Text VideoLabel;
	public Text ControllerLabel;
	public GameObject PlayerOneGameObject;
	public GameObject PlayerTwoGameObject;
	public Image PlayerOneCheckmark;
	public Image PlayerTwoCheckmark;
	public Image ControlPage;
	public bool VideoIsPlaying;
	public IntroVideo VidScript;

	// Use this for initialization
	void Start () {
		VidScript.enabled = true;
		ControllerLabel.gameObject.SetActive (false);
		ControlPage.gameObject.SetActive (false);
		VideoLabel.gameObject.SetActive (true);
		ControlsButton.onClick.AddListener (LookAtControls);
		VideoButton.onClick.AddListener (LookAtVideo);
		PlayerOneIsReady = false;
		PlayerTwoIsReady = false;
		BothPlayersAreReady = false;
		PlayerOneGameObject.gameObject.SetActive (true);
		PlayerTwoGameObject.gameObject.SetActive (true);
		PlayerOneCheckmark.gameObject.SetActive (false);
		PlayerTwoCheckmark.gameObject.SetActive (false);
		VidPlayer = gameObject.AddComponent<VideoPlayer> ();
		TutorialRawImage.texture = VidPlayer.texture;
		
	}
	void LookAtControls(){
		TutorialRawImage.gameObject.SetActive(false);
		VidScript.enabled = false;
		VidPlayer.enabled = false;
		print ("LOOKING AT CONTROLS");
		ControllerLabel.gameObject.SetActive (true);
		VideoLabel.gameObject.SetActive (false);
		VidPlayer.Stop ();
		ControlPage.gameObject.SetActive (true);

	

	}
	void LookAtVideo(){ 
		TutorialRawImage.gameObject.SetActive(true);
		VidScript.enabled = true;
		VidPlayer.timeReference = 0;
		print ("LOOKING AT VIDEO");	
		ControllerLabel.gameObject.SetActive (false);
		VideoLabel.gameObject.SetActive (true);
		ControlPage.gameObject.SetActive (false);
		VidPlayer.gameObject.SetActive (true);

	}
	void Check(){
		 if (!PlayerTwoCheckmark.enabled || !PlayerOneCheckmark.enabled) {
			BothPlayersAreReady = false;
			print ("both are not ready");
		}

		if (PlayerOneIsReady) {
			PlayerOneCheckmark.gameObject.SetActive (true);
			PlayerOneGameObject.gameObject.SetActive (false);
			print ("Player One is Ready!");
		}else if (!PlayerOneIsReady) {
			PlayerOneCheckmark.gameObject.SetActive (false);
			PlayerOneGameObject.gameObject.SetActive (true);
			print ("Player One is Not Ready!");
		}

		if (PlayerTwoIsReady) {
			PlayerTwoGameObject.gameObject.SetActive (false);
			PlayerTwoCheckmark.gameObject.SetActive (true);
			print ("Player Two is Ready!");
		}  else if (!PlayerTwoIsReady) {
			PlayerTwoGameObject.gameObject.SetActive (true);
			PlayerTwoCheckmark.gameObject.SetActive (false);
			print ("Player Two is Not Ready");
		}
		if (BothPlayersAreReady) {
			print ("Both are ready");
		}
		

	}
	void CheckingPlayerControls(){
		if(Input.GetKeyDown("f")){
			PlayerOneIsReady=!PlayerOneIsReady;
			Check ();
		}
		if (Input.GetKeyDown ("j")) {
			PlayerTwoIsReady = !PlayerTwoIsReady;
			Check ();
		}

	}

	// Update is called once per frame
	void Update () {
		if (PlayerTwoCheckmark.isActiveAndEnabled && PlayerOneCheckmark.isActiveAndEnabled) {
			PlayerOneIsReady = true;
			PlayerTwoIsReady = true;
			BothPlayersAreReady = true;
		} else {
			BothPlayersAreReady = false;
		}
		
		CheckingPlayerControls ();
	//Check ();

		
	}
}