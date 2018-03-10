﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TriggerMiniGame : MonoBehaviour {

    public GameObject p1, p2;
    public GameObject cam;
    public GameObject triggers;
    public GameObject LoadScreen;
    public Vector3 target;
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
            //other.gameObject.GetComponent<MoveTo>().agent.isStopped = true;
            /*p1.SetActive(false);
            p2.SetActive(false);
            cam.SetActive(false);
            triggers.SetActive(false);*/
            GlobalData.Wharf = false;
            
            StartCoroutine("LoadNewScene",other.gameObject);
            //SceneManager.LoadScene(LevelName);
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

    IEnumerator LoadNewScene(GameObject player)
    {

        player.GetComponent<MoveTo>().agent.isStopped = true;
        cam.GetComponent<CameraFollow>().enabled = false;
        Vector3 original = cam.transform.position;
        //target.z = original.z;
        Quaternion rotate = cam.transform.rotation;
        //cam.transform.LookAt(gameObject.transform);
        float transitionTime = 3.5f;
        while (transitionTime > 0)
        {
            //cam.transform.Translate();
            transitionTime -= .02f;
            cam.transform.position = Vector3.Lerp(original, target, (3.5f - transitionTime) / 3.5f);
            

            yield return new WaitForSeconds(.02f);
        }
        
        yield return new WaitForSeconds(1f);
        LoadScreen.SetActive(true);
        //cam.transform.rotation = rotate;
        cam.transform.position = original;
        cam.GetComponent<CameraFollow>().enabled = false;
        //cam.transform.rotation = original;
        //p1.GetComponent<MoveTo>().agent.isStopped = true;
        //p2.GetComponent<MoveTo>().agent.isStopped = true;
        // This line waits for 3 seconds before executing the next line in the coroutine.
        // This line is only necessary for this demo. The scenes are so simple that they load too fast to read the "Loading..." text.
        yield return new WaitForSeconds(3);

        // Start an asynchronous operation to load the scene that was passed to the LoadNewScene coroutine.
        AsyncOperation async = SceneManager.LoadSceneAsync(LevelName);
        // While the asynchronous operation to load the new scene is not yet complete, continue waiting until it's done.
        while (!async.isDone)
        {
            p1.SetActive(false);
            p2.SetActive(false);
            cam.SetActive(false);
            triggers.SetActive(false);
            yield return null;
        }

    }
}
