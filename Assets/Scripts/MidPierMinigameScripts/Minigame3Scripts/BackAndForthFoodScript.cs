using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackAndForthFoodScript : MonoBehaviour {
	public float XSpeed=1f;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.Translate (XSpeed, 0, 0);
		print (transform.position.x);
		if (transform.position.x >= 756) {
			XSpeed--;
		} else if (transform.position.x <= -32) {
			XSpeed++;
		}
	}
}
