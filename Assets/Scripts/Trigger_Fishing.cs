using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Fishing : MonoBehaviour {
    int count = 0;
    public GameObject Switch;
    private OnSwitch Change;
    void Start()
    {
        Change = Switch.GetComponent<OnSwitch>();
    }
    void OnTriggerEnter2D (Collider2D other) {
        count++;
        if (count == 1)
        {
            if (other.gameObject.name == "Player1")
            {
                Debug.Log("Player1 has entered Fishing");
            }
            else if (other.gameObject.name == "Player2")
            {
                Debug.Log("Player2 has entered Fishing");
            }
            // If count is 2
        } else
        {
            Debug.Log("Player1 and Player2 have entered Fishing");
        }
        //other.gameObject.GetComponent<MoveTo>().agent[GlobalData.turn].isStopped = true;
        if (other.gameObject.name == "Player" + (GlobalData.turn + 1))
        {
            Change.TaskOnClick();
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
            Debug.Log("Player1 has left Fishing");
        }
        else if (other.gameObject.name == "Player2")
        {
            Debug.Log("Player2 has left Fishing");
        }
    } 
}
