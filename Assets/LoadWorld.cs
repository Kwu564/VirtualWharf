using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadWorld : MonoBehaviour {
    public GameObject p1, p2;
    public GameObject cam;
    public GameObject triggers;
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelLoad;

    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelLoad;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnLevelLoad(Scene scene,LoadSceneMode mode)
    {
        if (scene.name == "sceneOne")
        {
            p1.SetActive(true);
            p2.SetActive(true);
            if (GlobalData.turn == 0)
            {
                p1.GetComponent<MoveTo>().Continue();
                p1.GetComponent<MoveTo>().moved = true;
            }
            else
            {
                p2.GetComponent<MoveTo>().Continue();
                p2.GetComponent<MoveTo>().moved = true;
                print("loaded p2");
            }
            cam.SetActive(true);
            triggers.SetActive(true);
        }
    }
}
