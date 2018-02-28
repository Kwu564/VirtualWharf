using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerCandyBoxMovement : MonoBehaviour {
	public float Speed;
	private Rigidbody2D CandyBox;
	// Use this for initialization
	void Start () {
		CandyBox=gameObject.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		MoveBackAndForth ();
		
	}
	void MoveBackAndForth(){
		if (Input.GetKey ("left")) {
			Vector2 Move = new Vector2 (-1, 0);
			Move = Move * Speed*Time.deltaTime;
			CandyBox.velocity = Move;
			Debug.Log ("Left");
		}
		else if (Input.GetKey ("right")) {
			Vector2 Move = new Vector2 (1, 0);
			Move = Move * Speed * Time.deltaTime;
			CandyBox.velocity = Move;
			Debug.Log ("Right");
		} else {
			CandyBox.velocity = Vector2.zero;
		}
	}
	void OnCollisionEnter2D(Collision2D Col){
		if (Col.gameObject.tag != "Player") {
			Destroy (Col.gameObject);
		}
		
	}
}
