using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfDrawnOver : MonoBehaviour {

	// Use this for initialization
	private Rigidbody2D Pencil;
	// Use this for initialization
	void Start () {
		Pencil=gameObject.GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {
	//	MoveBackAndForth ();

	}

	void OnCollisionEnter2D(Collision2D Col){
		if (Col.gameObject.tag != "Pencil") {
			//Destroy (Col.gameObject);
			print("touched");
		}

	}
}
