using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TriggerMiniGame : MonoBehaviour {

    public GameObject p1, p2;
    public GameObject cam;
    public GameObject triggers;
    public string LevelName;
    //private bool triggered = false;
    void Start()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        //other.gameObject.GetComponent<MoveTo>().agent[GlobalData.turn].isStopped = true;
        bool trigger = other.gameObject.GetComponent<MoveTo>().triggered;
        if (!trigger)
        {
            other.gameObject.GetComponent<MoveTo>().triggered = true;
            p1.SetActive(false);
            p2.SetActive(false);
            cam.SetActive(false);
            triggers.SetActive(false);
            SceneManager.LoadScene(LevelName);
            //gameObject.SetActive(false);

        }

        //gameObject.GetComponent<Collider>().enabled = false;
    }

    void OnTriggerStay()
    {

    }

    void OnTriggerExit(Collider other)
    {
        other.gameObject.GetComponent<MoveTo>().triggered = false;
    }
}
