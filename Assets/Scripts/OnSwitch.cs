﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Allows access to Button type
using UnityEngine.UI;

public class OnSwitch : MonoBehaviour {
    // The UI type that triggers our switch mechanism
    public Button button;
    public GameObject cam;
    public GameObject Player1, Player2;
    // Use this for initialization
    void Awake()
    {
        GlobalData.turn = 0;
        //GameObject.Find("Player1").GetComponent<MoveTo>().isMoving = true;
        //GameObject.Find("Player2").GetComponent<MoveTo>().isMoving = false;
    }
    void Start () {
        // Get the Button component
        Button btn = button.GetComponent<Button>();
        
        // Add a listener that listens to clicks
        btn.onClick.AddListener(TaskOnClick);
	}
	
    // Click triggers switch
    public void TaskOnClick()
    {
        if (GlobalData.turn == 0)
        {
            cam.GetComponent<CameraFollow>().target = Player2.transform;
            GameObject.Find("Player2").GetComponent<MoveTo>().moved = false;
            Debug.Log("Switch to 2");
            /*GameObject.Find("Player2").GetComponent<MoveTo>().agent.isStopped = true;
            GameObject.Find("Player1").GetComponent<MoveTo>().isMoving = true;            
            GameObject.Find("Player2").GetComponent<MoveTo>().isMoving = false;*/
            GlobalData.turn = 1;
        } else if (GlobalData.turn == 1)
        {
            cam.GetComponent<CameraFollow>().target = Player1.transform;
            GameObject.Find("Player1").GetComponent<MoveTo>().moved = false;
            Debug.Log("Switch to 1");
            /*GameObject.Find("Player2").GetComponent<MoveTo>().isMoving = true;
            GameObject.Find("Player1").GetComponent<MoveTo>().agent.isStopped = true;
            GameObject.Find("Player1").GetComponent<MoveTo>().isMoving = false;*/
            GlobalData.turn = 0;
        }
        Debug.Log("Switch players!");
    }
}