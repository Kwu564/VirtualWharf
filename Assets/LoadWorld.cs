using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadWorld : MonoBehaviour
{
    public  GameObject p1, p2;
    public  GameObject cam;
    public  GameObject triggers;
    public bool start;
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
        start = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*if(start == true)
        {
            MinigameEnd();
        }*/
    }

    void OnLevelLoad(Scene scene, LoadSceneMode mode)
    {
        print("Load");
        if (scene.name == "sceneOne")
        {
            Time.timeScale = 1;
            GlobalData.Wharf = true;
            DynamicGI.UpdateEnvironment();
            Minigame3Data.clear();
            MiniGame2Data.clear();
                p1.SetActive(true);
                p2.SetActive(true);
                cam.SetActive(false);
                cam.SetActive(true);
            triggers.SetActive(true);
            //StartCoroutine("MinigameEnd");
            if (p1.GetComponent<MoveTo>().moved == true)
                {
                    //p1.GetComponent<MoveTo>().moved = true;
                    //p2.GetComponent<MoveTo>().moved = false;
                    p1.GetComponent<MoveTo>().Continue();

                }
                else
                {
                    p2.GetComponent<MoveTo>().Continue();
                    //p2.GetComponent<MoveTo>().moved = true;
                    //p1.GetComponent<MoveTo>().moved = false;
                    print("loaded p2");
                }
                print("Turn:" + GlobalData.turn);
                
            
        }
        else
        {

            //GameObject.Find()
            try
            {
                foreach (Transform child in transform)
                {
                    child.gameObject.SetActive(false);
                }
            }
            catch { }
        }
    }

}