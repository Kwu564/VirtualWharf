using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class testAddItem : MonoBehaviour {
    //private GameObject thing;
    public string key;
    public GameObject prefab;
    //public List<GameObject> prefabs;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(key))
        {
            //thing = GameObject.Instantiate(prefab);
            GlobalData.P1Inventory.Add(prefab);
        }
        if (Input.GetKeyDown("p"))
        {
            foreach(GameObject item in GlobalData.P1Inventory)
            {
                print(item);
            }
        }
        if (Input.GetKeyDown("s"))
        {
            SceneManager.LoadScene("sceneOne");
        }
	}
}
