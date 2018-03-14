using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class CandyHint : MonoBehaviour {
	public Text blah;
	//public bool ShowHintForABit;

	// Use this for initialization
	void Start () {
		//ShowHintForABit = true;
		StartCoroutine ("PlayHintCoroutine");
	}
	IEnumerator PlayHintCoroutine(){
		blah.text = ("Collect the candy that is in the box");
		yield return new WaitForSeconds (4);
		blah.text = (" ");
	}
	
	// Update is called once per frame
	void Update () {
	}
}
