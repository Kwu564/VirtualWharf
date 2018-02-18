using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class Scaler : MonoBehaviour {
    public float speed;
    private Collider2D scaler;
    // Use this for initialization
    void Start () {
        scaler = gameObject.GetComponent<CapsuleCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
        var move = new Vector3(ReInput.players.GetPlayer(0).GetAxis("Scale"), 0, 0);
        transform.position += move * speed * Time.deltaTime;
        if (ReInput.players.GetPlayer(0).GetAxis("Scale") >= 0)
        {
            scaler.enabled = false;
        }else
        {
            scaler.enabled = true;
        }
    }
}
