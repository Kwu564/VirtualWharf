using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
public class Hose : MonoBehaviour {
    private Rigidbody2D rgbd;
    public float speed;
    private Player player;
    public int id;
    // Use this for initialization
    void Start () {
        rgbd = gameObject.GetComponent<Rigidbody2D>();
        player = ReInput.players.GetPlayer(id);
    }
	
	// Update is called once per frame
	void Update () {
        float x = player.GetAxis("HoseX");
        float y = player.GetAxis("HoseY");
        Vector2 move = new Vector2(x,y);
        rgbd.velocity = move * speed * Time.deltaTime;
        /*if (move == Vector2.zero)
        {
            rgbd.velocity = Vector2.zero;
        }*/
        print(move);
    }
}
