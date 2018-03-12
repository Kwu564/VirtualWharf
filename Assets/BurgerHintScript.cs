using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerHintScript : MonoBehaviour {
	public GameObject BurgerHintGameObject;
	public FoodMovement FoodMovementScript;

	// Use this for initialization
	void Start () {
		BurgerHintGameObject.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		if (FoodMovementScript.controls != null) {
			if (FoodMovementScript.controls.GetButtonDown ("stop")) {
				BurgerHintGameObject.SetActive (false);
			}	
		}
	}
}
