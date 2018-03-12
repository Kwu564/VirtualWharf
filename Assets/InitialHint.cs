using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialHint : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!GlobalData.FirstLoad)
        {
            gameObject.SetActive(false);
        }
	}
}
