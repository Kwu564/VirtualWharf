using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class init : MonoBehaviour {

    private void Awake()
    {
        if (GlobalData.players[0] == null || GlobalData.players[1] == null)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
