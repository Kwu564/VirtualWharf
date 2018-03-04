using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadWorld : MonoBehaviour
{
    public GameObject p1, p2;
    public GameObject cam;
    public GameObject triggers;
    private void Awake()
    {
        SceneManager.sceneLoaded += OnLevelLoad;

    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelLoad;
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnLevelLoad(Scene scene, LoadSceneMode mode)
    {
        print("Load");
        if (scene.name == "sceneOne")
        {
            p1.SetActive(true);
            p2.SetActive(true);
            if (p1.GetComponent<MoveTo>().moved == false)
            {
            p1.GetComponent<MoveTo>().Continue();
            //p1.GetComponent<MoveTo>().moved = true;
            //p2.GetComponent<MoveTo>().moved = false;
            }
            else
            {
            p2.GetComponent<MoveTo>().Continue();
            //p2.GetComponent<MoveTo>().moved = true;
            //p1.GetComponent<MoveTo>().moved = false;
            print("loaded p2");
            }
            print("Turn:" + GlobalData.turn);
            cam.SetActive(true);
            triggers.SetActive(true);
        }
        else
        {
            //GameObject.Find()
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
        }
    }

}