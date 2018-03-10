using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Rewired;
public class PauseMenu : MonoBehaviour
{
    public GameObject InGameMenuPopUp;
    public bool pauseMenuShows;

    // Use this for initialization
    void Start()
    {
        Canvas popupMenu = InGameMenuPopUp.GetComponentInParent<Canvas>();
        pauseMenuShows = false;
    }
    void onPause()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            pauseMenuShows = !pauseMenuShows;

        }
    }
    // Update is called once per frame
    void Update()
    {
        onPause();
        if (!pauseMenuShows)
        {
            //onPause();
            // unpause
            Time.timeScale = 1;
            // don't show pause screen
            InGameMenuPopUp.SetActive(false);
        }
        else if (pauseMenuShows)
        {
            //onPause();
            // pause
            Time.timeScale = 0;
            // show pause screen
            InGameMenuPopUp.SetActive(true);
        }
    }
}
