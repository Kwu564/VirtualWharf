using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class RotateSquare : MonoBehaviour {
	public BoxCollider2D CheckSideOne;
	public bool IsTouchingSideOne;
	//public Quaternion rotation = Quaternion.EulerAngles(new Vector3(0,90,0));

	// Use this for initialization
	void Start () {
		CheckSideOne = gameObject.GetComponent<BoxCollider2D> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space")) {
			//transform.Rotate (0, 90, 0, Space.World);
			transform.Rotate (0f,0f,90f, Space.World);
		}
		
	}

}
