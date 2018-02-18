﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
using UnityEngine.UI;
public class Scaler : MonoBehaviour {
    public float speed;
    private Collider2D scaler;
    public Rigidbody2D rgb2d;
    public float lowerbound;
    public float upperbound;
    public bool on;
    public int HP = 17;
    public Slider Health;
    [SerializeField] private int id;
    // Use this for initialization
    void Start () {
        scaler = gameObject.GetComponent<CapsuleCollider2D>();
        Health.value = Health.maxValue - HP;
	}
	
	// Update is called once per frame
	void Update () {
        var move = new Vector2(ReInput.players.GetPlayer(id).GetAxis("Scale"), 0);
        rgb2d.velocity = (move * speed * Time.deltaTime);
        if(move == Vector2.zero)
        {
            rgb2d.velocity = Vector2.zero;
            rgb2d.angularVelocity = 0;
        }
        if (ReInput.players.GetPlayer(id).GetAxis("Scale") >= 0)
        {
            this.on = false;
            print(on);
        }else
        {
            this.on = true;
        }
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
        Health.value = Health.maxValue - HP;
    }
    public void rumble()
    {

    }
}
