using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
using Rewired.ControllerExtensions;
public class MousePainting : MonoBehaviour {
	public GameObject Dot;
    public Player player;
    public int id;
    public Rewired.ControllerExtensions.DualShock4Extension ds4;
    // Use this for initialization
    void Start()
    {
        player = ReInput.players.GetPlayer(id);
        foreach (Joystick joystick in player.controllers.Joysticks)
        {
            // Get the Dual Shock 4 Controller Extension from the Joystick
            ds4 = joystick.GetExtension<Rewired.ControllerExtensions.DualShock4Extension>();
            if (ds4 == null) continue; // this is not a DS4, skip it
        }
    }
	void OnGUI(){
		if (Input.GetMouseButton(0)) {
			//print ("dragging");
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 10;
            Instantiate (Dot,pos, Quaternion.identity,transform);
	
		}
	}
	// Update is called once per frame
	void Update () {

        bool touch1isTouching;
        Vector2 touch1Pos;
        touch1isTouching = ds4.GetTouchPosition(0,out touch1Pos);
        if (touch1isTouching && player.GetButton("paint"))
        {
            Vector3 pos = Camera.main.ViewportToWorldPoint(touch1Pos);
            pos.z = 10;
            Instantiate(Dot, pos, Quaternion.identity, transform);
        }
        //print(ds4);
    }
}
