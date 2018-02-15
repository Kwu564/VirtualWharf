﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_SouvenirShop : MonoBehaviour {
    int count = 0;
    public GameObject Switch;
    private OnSwitch Change;
    void Start()
    {
        Change = Switch.GetComponent<OnSwitch>();
    }
    void OnTriggerEnter (Collider other) {
        //other.gameObject.GetComponent<MoveTo>().agent[GlobalData.turn].isStopped = true;
        if (other.gameObject.name == "Player" + (GlobalData.turn + 1))
        {
            Change.TaskOnClick();
        }
        count++;
        if (count == 1)
        {
            if (other.gameObject.name == "Player1")
            {
                Debug.Log("Player1 has entered the SouvenirShop");
            }
            else if (other.gameObject.name == "Player2")
            {
                Debug.Log("Player2 has entered the SouvenirShop");
            }
            // If count is 2
        } else
        {
            Debug.Log("Player1 and Player2 have entered the SouvenirShop");
        }
        
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
    }
	
	void OnTriggerStay () {

	}

    void OnTriggerExit (Collider other)
    {
        count--;
        if (other.gameObject.name == "Player1")
        {
            Debug.Log("Player1 has left the SouvenirShop");
        }
        else if (other.gameObject.name == "Player2")
        {
            Debug.Log("Player2 has left the SouvenirShop");
        }
    } 
}
