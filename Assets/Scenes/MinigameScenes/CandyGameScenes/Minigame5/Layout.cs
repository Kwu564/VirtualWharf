using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Layout : MonoBehaviour {

    public string MyText;
    public GameObject Kp_Display;

    public void MyFunction (string MyCount)
    {
        print("Canceled");
        MyText = "";
        MyCount = "";
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Text text = Kp_Display.GetComponent<Text>();
        text.text = MyText;
	}
}
