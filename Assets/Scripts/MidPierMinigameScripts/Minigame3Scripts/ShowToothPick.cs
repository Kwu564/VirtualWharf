using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class ShowToothPick : MonoBehaviour {
	public BoxCollider2D ToothpickCollider;
	public BoxCollider2D LastStickCollider;
	float speed=20f;
	public float stop;
	// Use this for initialization
	void Start () {
		
	}
	private void CheckTouch(){
		if (transform.position.y <= stop) {
			speed = 0f;
			transform.Translate (0,speed, 0);

			//transform.Translate (0,speed, 0);
		} else {
			//speed--;
			transform.Translate (0,-speed, 0);
		}
	//	transform.Translate (0,speed, 0);
	}
	// Update is called once per frame
	void Update () {
		
			
		/*if (ToothpickCollider.IsTouching (LastStickCollider)) {
			transform.Translate (0, 0, 0);
			}else{

*/

			//if (Time.timeScale == 0) {
			//speed--;
		//	transform.Translate (0, speed, 0);
			if (Time.timeScale == 0)
				CheckTouch ();

		
			//transform.Translate (0, -speed*Time.deltaTime, 0);
			//transform.Translate (0,speed, 0);

		}







	}

