using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using Rewired;
using UnityEngine;

public class BackToTitleFromCredits : MonoBehaviour {
	private Player P1;
	// Use this for initialization
	void Start () {
		P1 = ReInput.players.GetPlayer (0);
		
		
	}
	
	// Update is called once per frame
	void Update () {
		if(P1.GetButton("BackButton")){
			SceneManager.LoadScene("MainMenu");
		}
		
	}
}
