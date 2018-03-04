using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class P1Fishes : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<Text>().text = MiniGame2Data.player1Fish.ToString();
	}
}
