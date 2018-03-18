﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class PracticeShowBurgerInfo : MonoBehaviour {
	public bool BurgerInfoIsShowing;
	public GameObject BurgerInfo;
	public Count count;
	public PauseMenu pause;
	public PracticeShowBurgerInfo show;

	// Use this for initialization
	void Awake () {
		Canvas BurgerMenuPopUp = BurgerInfo.GetComponentInParent<Canvas>();
		BurgerInfoIsShowing = false;
		pause.enabled = false;
		show.enabled = false;
		//count.enabled = false;
		//Time.timeScale = 0;
		StartCoroutine ("AfterCountdown");
	}
	IEnumerator AfterCountdown(){
		pause.enabled = false;
		yield return new WaitForEndOfFrame();
		Time.timeScale = 0.0f;
		int time = 4;
		while (time>0) {
			BurgerInfoIsShowing = false;
			yield return new WaitForSecondsRealtime (1f);
			time--;
			//BurgerInfoIsShowing = true;
		}
		show.enabled = true;
		pause.enabled = false;
		BurgerInfoIsShowing = true;
		yield return new WaitForSecondsRealtime (1f);
		BurgerInfoIsShowing = false;
		//Time.timeScale = 1;
		pause.enabled = true;
		//count.enabled = true;


	}
	// Update is called once per frame
	void Update () {
		if (BurgerInfoIsShowing == false) {
			BurgerInfo.SetActive (false);
			Time.timeScale = 1;
		} else if (BurgerInfoIsShowing == true) {
			BurgerInfo.SetActive (true);
			Time.timeScale = 0;
		}

	}
}
