using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePainting : MonoBehaviour {
	public GameObject Dot;
	// Use this for initialization
	void Start () {
		
	}
	void OnGUI(){
		if (Input.GetMouseButton(0)) {
			print ("dragging");
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 10;
            Instantiate (Dot,pos, Quaternion.identity,transform);
	
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
}
