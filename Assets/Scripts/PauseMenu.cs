using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Rewired;
public class PauseMenu : MonoBehaviour {
	public GameObject InGameMenuPopUp;
	public bool pauseMenuShows;

	// Use this for initialization
	void Start () {
		Canvas popupMenu = InGameMenuPopUp.GetComponentInParent<Canvas>();
        pauseMenuShows = false;
	}
	void onPause(){
		if (Input.GetKeyDown (KeyCode.P)  ) {
            print("toggle");
			pauseMenuShows = !pauseMenuShows;
            
        }
	}
	// Update is called once per frame
	void Update () {
        onPause();
        if (!pauseMenuShows)
        {
            //onPause();
            // unpause
            if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
            }
            // don't show pause screen
            InGameMenuPopUp.SetActive(false);
            print(Time.timeScale);
        }
        else if (pauseMenuShows)
        {
            //onPause();
            // pause
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
            }
            // show pause screen
            InGameMenuPopUp.SetActive(true);
            print(Time.timeScale);
        }
        //print(Time.timeScale);
    }
}
