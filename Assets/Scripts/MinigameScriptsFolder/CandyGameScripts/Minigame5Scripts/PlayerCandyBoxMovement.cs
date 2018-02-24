using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCandyBoxMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		MoveBackAndForth ();
		
	}
	void MoveBackAndForth(){
		if (Input.GetKeyDown ("left")) {
			Debug.Log ("Left");
		}
		if (Input.GetKeyDown ("right")) {
			Debug.Log ("Right");
		}
	}
}
