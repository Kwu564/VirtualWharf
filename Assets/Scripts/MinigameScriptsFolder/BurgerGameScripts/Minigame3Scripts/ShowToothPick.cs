using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class ShowToothPick : MonoBehaviour {
	//public BoxCollider2D ToothpickCollider;
	//public BoxCollider2D LastStickCollider;
    public GameObject stop;
    public int player;
	float speed=20f;
	//public float stop;
	// Use this for initialization
	void Start () {
		
	}
	private void CheckTouch(){
        transform.localPosition = Vector3.Lerp(transform.localPosition, stop.transform.localPosition, speed * Time.deltaTime);
        
    }
	// Update is called once per frame
	void Update () {
        
        if (Minigame3Data.Checked[player,0] >= 9)
                CheckTouch ();

    }







	}

