using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleCollision : MonoBehaviour {
    private BoxCollider2D scale;
	// Use this for initialization
	void Start () {
        scale = gameObject.GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        print("I'm hit" + gameObject.ToString());
    }
}
