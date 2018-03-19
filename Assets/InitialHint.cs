using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InitialHint : MonoBehaviour {
    public Text WhoseTurn;
    public GameObject hint;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (GlobalData.turn >= 2)
        {
            hint.SetActive(false);
        }
	}
}
