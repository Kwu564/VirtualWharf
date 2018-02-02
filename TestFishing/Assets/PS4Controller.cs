﻿using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;

public class PS4Controller : MonoBehaviour {
	public GameObject PlayButtonMM;
	public GameObject[] Buttons;
	[SerializeField] private float scrollSpeed;
	private int x = 0;
	void Start () {
		InvokeRepeating ("getInput",0,scrollSpeed);
	}

	// Update is called once per frame
	void Update () {
		Buttons [x].SendMessage ("OnMouseOver");
		for (int i = 0; i < Buttons.Length; i++) {
			if (i != x) {
				Buttons [i].SendMessage ("OnMouseExit");
			}
		}
	}


	void getInput(){
		//float horizontal = CrossPlatformInputManager.GetAxis ("Horizontal");
		float vertical = CrossPlatformInputManager.GetAxis ("Vertical");
		//print (vertical);
		if (vertical < 0f) {
			x = (x + 1) % Buttons.Length;
		} else if (vertical > 0f) {
			x = (x+3) % Buttons.Length;
			//print(((x - 1)+4)%Buttons.Length);
		}
		//print (x);
	}
}